using ProjektC.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace ProjektC
{
    public partial class Podcasts : Form
    {
        private HttpClient Client = new HttpClient();
        //private WebPageList listofwebpages = new WebPageList(); 

        
        List<string> KategoriLista = new List<string>();
        List<Podcast> PodcastLista = new List<Podcast>();
 

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
                //Här ska de va kod hör kopplar vi nyknappen till själva rutan.
                // lvPodcasts.Items.Add(pod.Url.ToString());
                ListViewItem item = new ListViewItem(txtURL.Text);
                item.SubItems.Add(cbFrekvens.Text);
                item.SubItems.Add(cbKategori.Text);

                lvPodcasts.Items.Add(item);
                txtURL.Clear();
                txtURL.Focus();
          }

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
            //Måste först göra en instans av en klass för att
            // kunna anropa dess klasser 
            var p = new Podcast();
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
                 lvPodcasts.Select();
                
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {     
            
        }
    }
    }

    //private void frek(){throw new NotImplementedException();}

    //private void Podcast(){throw new NotImplementedException}

