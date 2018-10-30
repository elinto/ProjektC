using ProjektC.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjektC
{
    public partial class Podcasts : Form
    {
        private HttpClient Client = new HttpClient();
        //private WebPageList listofwebpages = new WebPageList(); 

        
        List<string> KategoriLista = new List<string>();
        List<Podcast> PodcastLista = new List<Podcast>();

        public object AvsnittLista { get; private set; }

        public Podcasts()
        {
            InitializeComponent();
            cbFrekvens.Items.Add("Var 10:e minut");
            cbFrekvens.Items.Add("Var 20:e minut");
            cbFrekvens.Items.Add("Var 30:e minut");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSparaKategori_Click(object sender, EventArgs e)
        {
            var oldValue = lbKategorier.SelectedItem.ToString();
            var newvalue = txtKategori.Text;
            int index = KategoriLista.IndexOf(oldValue);
            if (index != -1)
            {
                KategoriLista[index] = newvalue;
            }
            UpdateKategoriListan();



        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            var kategori = txtKategori.Text;
            if (!KategoriLista.Contains(kategori))
            {
                KategoriLista.Add(kategori);
            }
            UpdateKategoriListan();
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

        private void UpdatePodcastListan() {

            foreach (var pod in PodcastLista) {

                var item1 = new ListViewItem(new[] { pod.Namn, pod.AntalAvsnitt, pod.Uppdateringsfrekvens, pod.Kategori });

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
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var deliteItem = lbKategorier.SelectedItem.ToString();
                KategoriLista.Remove(deliteItem);
                UpdateKategoriListan();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void cbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void btnNy_Click(object sender, EventArgs e)
        {
            //var MyRequest = WebRequest.Create(txtURL.Text);
            //var MyRespone = MyRequest.GetResponse();

            //var stream = MyRespone.GetResponseStream();
            //var xmlDoc = new XmlDocument();
            //xmlDoc.Load(stream);
            XmlDocument document = new XmlDocument();
            document.Load(txtURL.Text);
            var title = document.SelectSingleNode("rss/channel/title");
            var avsnittLista = document.SelectNodes("rss/channel/item");
            //var avsnittLista = xmlDoc.SelectNodes("rss/channel/item");
            //var title = xmlDoc.SelectSingleNode("rss/channel/title");
            var p = new Podcast();
            p.Url = txtURL.Text;
            p.AntalAvsnitt = avsnittLista.Count.ToString();
            p.Namn = title.InnerText;

            foreach (XmlNode xmlAvsnitt in avsnittLista)
            {
                var avsnitt = new PodcastAvsnitt();
                avsnitt.Titel = xmlAvsnitt.SelectSingleNode("title").InnerText;
                avsnitt.Beskrivning = xmlAvsnitt.SelectSingleNode("description").InnerText;


                //avsnitt.Titel = avsnittTitel;
                //avsnitt.Beskrivning = avsnittBeskrivning.ToString();

                p.AvsnittLista.Add(avsnitt);

            }


            if (!PodcastLista.Contains(p))
            {
                p.Url = txtURL.Text;
                p.Kategori = cbKategori.SelectedItem.ToString();
                p.Uppdateringsfrekvens = cbFrekvens.SelectedItem.ToString();
                PodcastLista.Add(p);
            }
            UpdatePodcastListan();
        }

        private void cbFrekvens_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var p = new Podcast();
            //p.Upddateringsfrekvens = cbFrekvens.ToString();
          // frek();  



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
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var foo = lvPodcasts.SelectedItems[0].Text;
                Console.WriteLine(foo);

                Podcast pod = PodcastLista.Find(x => x.Namn == foo);

                foreach(var avsnitt in pod.AvsnittLista)
                {
                    lbAvsnitt.Items.Add(avsnitt.Titel);
                }
                
                
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }


        private void btnSpara_Click(object sender, EventArgs e)
        {

            //var oldValue = lvPodcasts.SelectedItems;
            //var newvalue = txtURL.Text;
            //int index = PodcastLista.IndexOf();
            //if (index != -1)
            //{
            //    KategoriLista[index] = newvalue;
            //}
            //UpdatePodcastListan();
        }

        //private void lbAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var listan = new Podcast();
        //        var boo = lbAvsnitt.SelectedItems.ToString();
        //        Console.WriteLine(boo);

        //        var pod = listan.AvsnittLista.Find(x => x.Titel == boo);

        //        foreach (var avsnitt in Listan)
        //        {
        //            lbAvsnitt.Items.Add(avsnitt.Titel);
        //        }




        //    }
        //    catch (Exception ex) { Console.WriteLine(ex); }
        //}

        private void lbAvsnitt_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void rTxtBeskrivning_TextChanged(object sender, EventArgs e)
        {

        }

    }
    }

    //private void frek(){throw new NotImplementedException();}

    //private void Podcast(){throw new NotImplementedException}

