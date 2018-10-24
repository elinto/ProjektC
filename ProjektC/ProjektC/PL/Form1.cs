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

        public Podcasts()
        {
            InitializeComponent();
        }
        //eheheh
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSparaKategori_Click(object sender, EventArgs e)
        {
            var oldValue = lbKategorier.SelectedItem.ToString();
            var newvalue = txtKategori.Text;
            int index = KategoriLista.IndexOf(oldValue);
            if (index!= -1)
            {
                KategoriLista[index] = newvalue;
            }
            UpdateKategoriListan();



        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            var kategori = txtKategori.Text;
            if (!KategoriLista.Contains(kategori)) {
                KategoriLista.Add(kategori);
            }
            UpdateKategoriListan();
        }

        private void UpdateKategoriListan() {
            lbKategorier.Items.Clear();
            cbKategori.Items.Clear();

            foreach (var kategori in KategoriLista) {
                lbKategorier.Items.Add(kategori);
                cbKategori.Items.Add(kategori);
            }

            txtKategori.Clear();
            
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

                //test

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
           

            foreach (var n in KategoriLista)
            {
                cbKategori.Text = n.ToString(); 
            }
            UpdateKategoriListan();

        }
    }

}
