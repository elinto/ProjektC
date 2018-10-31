using ProjektC.BLL;
using ProjektC.DAL;
using System;
using System.Collections.Generic;
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
            }

            catch (PodcastException ex)
            {
                Console.WriteLine(ex);
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

            catch (PodcastException ex)
            {
                Console.WriteLine(ex);
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
            foreach (var pod in PodcastLista)
            {

                var item1 = new ListViewItem(new[] {
                    pod.Namn,
                    pod.AntalAvsnitt,
                    pod.Uppdateringsfrekvens,
                    pod.Kategori
                });

                lvPodcasts.Items.Add(item1);
            }
            txtURL.Clear();

        }

        private void lbKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtKategori.Text = lbKategorier.SelectedItem.ToString();
            }
            catch (PodcastException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var deliteItem = lbKategorier.SelectedItem.ToString();
                KategoriLista.Remove(deliteItem);
                UpdateKategoriListan();
                KategoriSerializer.SaveKategorier(KategoriLista);
            }

            catch (PodcastException ex)
            {
                Console.WriteLine(ex);
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
                p.Url = txtURL.Text;
                p.AntalAvsnitt = avsnittLista.Count.ToString();
                p.Namn = title.InnerText;
                p.Kategori = cbKategori.SelectedItem.ToString();
                p.Uppdateringsfrekvens = cbFrekvens.SelectedItem.ToString();

                foreach (XmlNode xmlAvsnitt in avsnittLista)
                {
                    var avsnitt = new PodcastAvsnitt();
                    avsnitt.Titel = xmlAvsnitt.SelectSingleNode("title").InnerText;
                    avsnitt.Beskrivning = xmlAvsnitt.SelectSingleNode("description").InnerText;
                    p.AvsnittLista.Add(avsnitt);
                }
                PodcastLista.Add(p);
                UpdatePodcastListan();
                PodcastSerializer.SavePodcasts(PodcastLista);
            }

            catch (PodcastException ex)
            {
                Console.WriteLine(ex);
            }
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

            catch (PodcastException ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedPodcastNamn = lvPodcasts.SelectedItems[0].Text;

                var pod = PodcastLista.Find(x => x.Namn == selectedPodcastNamn);
                valdPodcast = pod;
                txtURL.Text = valdPodcast.Url;
                cbFrekvens.Text = valdPodcast.Uppdateringsfrekvens;
                cbKategori.Text = valdPodcast.Kategori;


                foreach (var avsnitt in pod.AvsnittLista)
                {
                    lbAvsnitt.Items.Add(avsnitt.Titel);
                }


            }
            catch (PodcastException ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void btnSpara_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedPodcastNamn = lvPodcasts.SelectedItems[0].Text;
                var pod = PodcastLista.Find(x => x.Namn == selectedPodcastNamn);
                valdPodcast = pod;



                //        //var oldValue = lbKategorier.SelectedItem.ToString();
                //var newvalue = txtKategori.Text;
                //int index = KategoriLista.IndexOf(oldValue);
                //    if (index != -1)
                //    {
                //        KategoriLista[index] = newvalue;
                //    }

                UpdatePodcastListan();
                PodcastSerializer.SavePodcasts(PodcastLista);

            }
            catch (PodcastException ex)
            { Console.WriteLine(ex); }
        }

        private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var valtAvsnittTitel = lbAvsnitt.SelectedItem.ToString();

                var valtAvsnitt = valdPodcast.AvsnittLista.Find(x => x.Titel == valtAvsnittTitel);

                txtBeskrivning.Text = valtAvsnitt.Beskrivning;

            }
            catch (PodcastException ex) {
                Console.WriteLine(ex);
            }
        }

    }
}


