﻿using ProjektC.BLL;
using ProjektC.BLL.Validering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjektC
{
    public partial class Podcasts : Form
    {
        private List<string> KategoriLista = new List<string>();
        private List<Podcast> PodcastLista = new List<Podcast>();
        private Podcast valdPodcast = null;
        private UrlValiderare urlValiderare = new UrlValiderare();
        private TextValiderare textValiderare = new TextValiderare();
        private ComboboxValiderare comboboxValiderare = new ComboboxValiderare();

        public Podcasts()
        {
            InitializeComponent();
            cbFrekvens.Items.Add("Var 10:e minut");
            cbFrekvens.Items.Add("Var 20:e minut");
            cbFrekvens.Items.Add("Var 30:e minut");

            PodcastLista = PodcastStorage.GetPodcasts();
            KategoriLista = KategoriStorage.GetKategorier();
            UpdatePodcastListan();
            UpdateKategoriListan();
            StartaUppdateringTimers();
        }

        private void StartaUppdateringTimers()
        {
            foreach (var p in PodcastLista)
            {
                StartaTimer(p);
            }
        }

        private void StartaTimer(Podcast p)
        {
            p.uppdateringsTimer.Interval = PodcastHelper.GetUppdateringsfrekvensMilliseconds(p.Uppdateringsfrekvens);
            p.uppdateringsTimer.Tick += async delegate
            {
                var document = await PodcastFetcher.FetchPodcastAsync(p.Url);

                var title = document.SelectSingleNode("rss/channel/title");
                var avsnittLista = document.SelectNodes("rss/channel/item");

                p.Titel = title.InnerText;
                p.AntalAvsnitt = avsnittLista.Count.ToString();
                PodcastHelper.SetAvsnitt(p, avsnittLista);

                UpdatePodcastListan();
                PodcastStorage.SavePodcasts(PodcastLista);
            };
            p.uppdateringsTimer.Start();
        }

        private void btnSparaKategori_Click(object sender, EventArgs e)
        {
            try
            {
                textValiderare.ValideraInput(txtKategori.Text);

                var oldValue = lbKategorier.SelectedItem.ToString();
                var newvalue = txtKategori.Text;
                int index = KategoriLista.IndexOf(oldValue);
                if (index != -1)
                {
                    KategoriLista[index] = newvalue;
                }
                UpdateKategoriListan();
                KategoriStorage.SaveKategorier(KategoriLista);
                SetNyKategoriPodcast(newvalue, oldValue);
            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        public void SetNyKategoriPodcast(string newValue, string oldValue) {
            var podcastsMedKategori = PodcastLista.Where(x => x.Kategori == oldValue).ToList();
            foreach (var p in podcastsMedKategori)
            {
                p.Kategori = newValue;
            }
            UpdatePodcastListan();
            PodcastStorage.SavePodcasts(PodcastLista);
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            try
            {
                textValiderare.ValideraInput(txtKategori.Text);

                var kategori = txtKategori.Text;
                if (!KategoriLista.Contains(kategori))
                {
                    KategoriLista.Add(kategori);
                }
                UpdateKategoriListan();
                KategoriStorage.SaveKategorier(KategoriLista);
            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }

        }

        private void UpdateKategoriListan()
        {
            lbKategorier.Items.Clear();
            cbKategori.Items.Clear();

            foreach (var kategori in KategoriLista)
            {
                lbKategorier.Items.Add(kategori);
                cbKategori.Items.Add(kategori);
            }

            txtKategori.Clear();
        }

        private void UpdatePodcastListan()
        {
            UpdatePodcastListan(null);
        }

        private void UpdatePodcastListan(string kategoriAttFiltrera)
        {
            lvPodcasts.Items.Clear();

            var podcastsAttVisa = PodcastLista;

            if (kategoriAttFiltrera != null)
            {
                podcastsAttVisa = PodcastLista.Where(x => x.Kategori == kategoriAttFiltrera).ToList();
            }

            foreach (var pod in podcastsAttVisa)
            {
                var item1 = new ListViewItem(new[] {
                    pod.Titel,
                    pod.AntalAvsnitt,
                    pod.Uppdateringsfrekvens,
                    pod.Kategori
                });

                lvPodcasts.Items.Add(item1);
            }
        }

        private void lbKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string kategori = lbKategorier.SelectedItem?.ToString();
                txtKategori.Text = kategori;
                UpdatePodcastListan(kategori);
            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var valdKategori = lbKategorier.SelectedItem.ToString();
                KategoriLista.Remove(valdKategori);
                UpdateKategoriListan();
                KategoriStorage.SaveKategorier(KategoriLista);
                TaBortPodcastMedKategori(valdKategori);
            }

            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }

        }

        private void TaBortPodcastMedKategori(string valdKategori) {
            var podCastsAttTaBort = PodcastLista.Where(x => x.Kategori == valdKategori).ToList();
            foreach (var p in podCastsAttTaBort)
            {
                p.uppdateringsTimer.Stop();
            }

            valdPodcast = null;

            PodcastLista = PodcastLista.Where(x => x.Kategori != valdKategori).ToList();
            UpdatePodcastListan();
            PodcastStorage.SavePodcasts(PodcastLista);
            UpdateAvsnittsListan();
            txtBeskrivning.Clear();
            ClearPodcastInputs();

        }

        private async void btnNy_Click(object sender, EventArgs e)
        {
            try
            {
                urlValiderare.ValideraInput(txtURL.Text);
                comboboxValiderare.ValideraInput((string)cbFrekvens.SelectedItem);
                comboboxValiderare.ValideraInput((string)cbKategori.SelectedItem);

                var document = await PodcastFetcher.FetchPodcastAsync(txtURL.Text);

                var title = document.SelectSingleNode("rss/channel/title");
                var avsnittLista = document.SelectNodes("rss/channel/item");

                var p = new Podcast();
                SetPodcastValues(p, title.InnerText, avsnittLista.Count);
                PodcastHelper.SetAvsnitt(p, avsnittLista);
                PodcastLista.Add(p);
                UpdatePodcastListan();
                PodcastStorage.SavePodcasts(PodcastLista);

                ClearPodcastInputs();

                StartaTimer(p);
            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        public void SetPodcastValues(Podcast p, string title, int antalAvsnitt)
        {
            p.Url = txtURL.Text;
            p.AntalAvsnitt = antalAvsnitt.ToString();
            p.Titel = title;
            p.Kategori = cbKategori.SelectedItem.ToString();
            p.Uppdateringsfrekvens = cbFrekvens.SelectedItem.ToString();
        }

        private void btnTabort_Click(object sender, EventArgs e)
        {
            try
            {
                valdPodcast.uppdateringsTimer.Stop();
                PodcastLista.Remove(valdPodcast);

                UpdatePodcastListan();
                PodcastStorage.SavePodcasts(PodcastLista);

                ClearPodcastInputs();
                UpdateAvsnittsListan();
                txtBeskrivning.Clear();
            }

            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }

        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvPodcasts.SelectedItems.Count == 0)
            {
                ClearPodcastInputs();
                valdPodcast = null;
                txtBeskrivning.Clear();
                UpdateAvsnittsListan();

                return;
            }

            try
            {
                var selectedPodcastNamn = lvPodcasts.SelectedItems[0].Text;

                var pod = PodcastLista.Find(x => x.Titel == selectedPodcastNamn);
                valdPodcast = pod;
                txtURL.Text = valdPodcast.Url;
                cbFrekvens.Text = valdPodcast.Uppdateringsfrekvens;
                cbKategori.Text = valdPodcast.Kategori;
                UpdateAvsnittsListan();
                txtBeskrivning.Clear();

            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        public void UpdateAvsnittsListan()
        {
            lbAvsnitt.Items.Clear();
            if (valdPodcast != null)
            {
                foreach (var avsnitt in valdPodcast.AvsnittLista)
                {
                    lbAvsnitt.Items.Add(avsnitt.Titel);
                }
            }
        }

        private async void btnSpara_Click(object sender, EventArgs e)
        {
            try
            {
                urlValiderare.ValideraInput(txtURL.Text);
                comboboxValiderare.ValideraInput((string)cbFrekvens.SelectedItem);
                comboboxValiderare.ValideraInput((string)cbKategori.SelectedItem);

                var document = await PodcastFetcher.FetchPodcastAsync(txtURL.Text);

                var title = document.SelectSingleNode("rss/channel/title");
                var avsnittLista = document.SelectNodes("rss/channel/item");

                SetPodcastValues(valdPodcast, title.InnerText, avsnittLista.Count);
                PodcastHelper.SetAvsnitt(valdPodcast, avsnittLista);

                UpdatePodcastListan();
                PodcastStorage.SavePodcasts(PodcastLista);

                valdPodcast.uppdateringsTimer.Stop();
                StartaTimer(valdPodcast);

                ClearPodcastInputs();
            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        private void ClearPodcastInputs()
        {
            txtURL.Clear();
            cbFrekvens.SelectedItem = null;
            cbKategori.SelectedItem = null;
        }

        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var valtAvsnittTitel = lbAvsnitt.SelectedItem.ToString();

                var valtAvsnitt = valdPodcast.AvsnittLista.Find(x => x.Titel == valtAvsnittTitel);

                txtBeskrivning.Text = valtAvsnitt.Beskrivning;

            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            lbKategorier.ClearSelected();
        }
    }
}


