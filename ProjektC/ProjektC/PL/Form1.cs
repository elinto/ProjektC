using ProjektC.BLL;
using ProjektC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ProjektC
{
    public partial class Podcasts : Form
    {
        List<string> KategoriLista = new List<string>();
        List<Podcast> PodcastLista = new List<Podcast>();
        Podcast valdPodcast = null;

        public Podcasts()
        {
            InitializeComponent();
            cbFrekvens.Items.Add("Var 10:e minut");
            cbFrekvens.Items.Add("Var 20:e minut");
            cbFrekvens.Items.Add("Var 30:e minut");

            PodcastLista = PodcastSerializer.GetPodcasts();
            KategoriLista = KategoriSerializer.GetKategorier();
            UpdatePodcastListan();
            UpdateKategoriListan();

        }

        private void btnSparaKategori_Click(object sender, EventArgs e)
        {
            try
            {
                var oldValue = lbKategorier.SelectedItem.ToString();
                var newvalue = txtKategori.Text;
                int index = KategoriLista.IndexOf(oldValue);
                if (index != -1)
                {
                    KategoriLista[index] = newvalue;
                }
                UpdateKategoriListan();
                KategoriSerializer.SaveKategorier(KategoriLista);

                var podcastsMedKategori = PodcastLista.Where(x => x.Kategori == oldValue).ToList();
                foreach (var p in podcastsMedKategori) {
                    p.Kategori = newvalue;
                }
                UpdatePodcastListan();
                PodcastSerializer.SavePodcasts(PodcastLista);
            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {

            try
            {
                var kategori = txtKategori.Text;
                if (!KategoriLista.Contains(kategori))
                {
                    KategoriLista.Add(kategori);
                }
                UpdateKategoriListan();
                KategoriSerializer.SaveKategorier(KategoriLista);
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

        private void UpdatePodcastListan(string kategoriAttFiltrera = null)
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
                    pod.Namn,
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
                KategoriSerializer.SaveKategorier(KategoriLista);

                PodcastLista = PodcastLista.Where(x => x.Kategori != valdKategori).ToList();
                UpdatePodcastListan();
                PodcastSerializer.SavePodcasts(PodcastLista);
            }

            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }

        }

        private void btnNy_Click(object sender, EventArgs e)
        {
            try
            {
                var document = new XmlDocument();
                document.Load(txtURL.Text);
                var title = document.SelectSingleNode("rss/channel/title");
                var avsnittLista = document.SelectNodes("rss/channel/item");

                var p = new Podcast();
                SetPodcastValues(p, title.InnerText, avsnittLista.Count);
                PodcastHelper.SetAvsnitt(p, avsnittLista);
                PodcastLista.Add(p);
                UpdatePodcastListan();
                PodcastSerializer.SavePodcasts(PodcastLista);

                ClearPodcastInputs();
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
            p.Namn = title;
            p.Kategori = cbKategori.SelectedItem.ToString();
            p.Uppdateringsfrekvens = cbFrekvens.SelectedItem.ToString();
        }

        private void btnTabort_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = lvPodcasts.Items.Count - 1; i >= 0; i--)
                {
                    if (lvPodcasts.Items[i].Selected)
                    {
                        lvPodcasts.Items[i].Remove();
                        PodcastLista.RemoveAt(i);
                    }
                }
                UpdatePodcastListan();
                PodcastSerializer.SavePodcasts(PodcastLista);
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
                return;
            }

            try
            {
                var selectedPodcastNamn = lvPodcasts.SelectedItems[0].Text;

                var pod = PodcastLista.Find(x => x.Namn == selectedPodcastNamn);
                valdPodcast = pod;
                txtURL.Text = valdPodcast.Url;
                cbFrekvens.Text = valdPodcast.Uppdateringsfrekvens;
                cbKategori.Text = valdPodcast.Kategori;
                UpdateAvsnittsListan();

            }
            catch (Exception ex)
            {
                ErrorHandler.HanteraFel(ex);
            }
        }

        public void UpdateAvsnittsListan()
        {
            lbAvsnitt.Items.Clear();

            foreach (var avsnitt in valdPodcast.AvsnittLista)
            {
                lbAvsnitt.Items.Add(avsnitt.Titel);
            }

        }


        private void btnSpara_Click(object sender, EventArgs e)
        {
            try
            {
                var document = new XmlDocument();
                document.Load(txtURL.Text);
                var title = document.SelectSingleNode("rss/channel/title");
                var avsnittLista = document.SelectNodes("rss/channel/item");

                SetPodcastValues(valdPodcast, title.InnerText, avsnittLista.Count);
                PodcastHelper.SetAvsnitt(valdPodcast, avsnittLista);

                UpdatePodcastListan();
                PodcastSerializer.SavePodcasts(PodcastLista);

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


