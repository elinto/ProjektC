namespace ProjektC
{
    partial class Podcasts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvPodcasts = new System.Windows.Forms.ListView();
            this.Avsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Namn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frekvens = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFrekvens = new System.Windows.Forms.ComboBox();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.btnNy = new System.Windows.Forms.Button();
            this.btnSpara = new System.Windows.Forms.Button();
            this.btnTabort = new System.Windows.Forms.Button();
            this.lbAvsnitt = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbKategorier = new System.Windows.Forms.ListBox();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.btnNyKategori = new System.Windows.Forms.Button();
            this.btnSparaKategori = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBeskrivning = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvPodcasts
            // 
            this.lvPodcasts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Avsnitt,
            this.Namn,
            this.Frekvens,
            this.Kategori});
            this.lvPodcasts.FullRowSelect = true;
            this.lvPodcasts.Location = new System.Drawing.Point(78, 58);
            this.lvPodcasts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvPodcasts.Name = "lvPodcasts";
            this.lvPodcasts.Size = new System.Drawing.Size(550, 229);
            this.lvPodcasts.TabIndex = 0;
            this.lvPodcasts.UseCompatibleStateImageBehavior = false;
            this.lvPodcasts.View = System.Windows.Forms.View.Details;
            this.lvPodcasts.SelectedIndexChanged += new System.EventHandler(this.lvPodcasts_SelectedIndexChanged);
            // 
            // Avsnitt
            // 
            this.Avsnitt.Text = "Avsnitt";
            // 
            // Namn
            // 
            this.Namn.Text = "Namn";
            this.Namn.Width = 62;
            // 
            // Frekvens
            // 
            this.Frekvens.Text = "Frekvens";
            this.Frekvens.Width = 92;
            // 
            // Kategori
            // 
            this.Kategori.Text = "Kategori";
            this.Kategori.Width = 335;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(57, 335);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(222, 26);
            this.txtURL.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Uppdateringsfrekvens:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kategori:";
            // 
            // cbFrekvens
            // 
            this.cbFrekvens.FormattingEnabled = true;
            this.cbFrekvens.Location = new System.Drawing.Point(300, 335);
            this.cbFrekvens.Name = "cbFrekvens";
            this.cbFrekvens.Size = new System.Drawing.Size(174, 28);
            this.cbFrekvens.TabIndex = 5;
            // 
            // cbKategori
            // 
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(482, 335);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(121, 28);
            this.cbKategori.TabIndex = 6;
            // 
            // btnNy
            // 
            this.btnNy.Location = new System.Drawing.Point(272, 402);
            this.btnNy.Name = "btnNy";
            this.btnNy.Size = new System.Drawing.Size(102, 35);
            this.btnNy.TabIndex = 7;
            this.btnNy.Text = "Ny...";
            this.btnNy.UseVisualStyleBackColor = true;
            this.btnNy.Click += new System.EventHandler(this.btnNy_Click);
            // 
            // btnSpara
            // 
            this.btnSpara.Location = new System.Drawing.Point(400, 405);
            this.btnSpara.Name = "btnSpara";
            this.btnSpara.Size = new System.Drawing.Size(92, 32);
            this.btnSpara.TabIndex = 8;
            this.btnSpara.Text = "Spara";
            this.btnSpara.UseVisualStyleBackColor = true;
            this.btnSpara.Click += new System.EventHandler(this.btnSpara_Click);
            // 
            // btnTabort
            // 
            this.btnTabort.Location = new System.Drawing.Point(508, 405);
            this.btnTabort.Name = "btnTabort";
            this.btnTabort.Size = new System.Drawing.Size(94, 32);
            this.btnTabort.TabIndex = 9;
            this.btnTabort.Text = "Ta bort...";
            this.btnTabort.UseVisualStyleBackColor = true;
            this.btnTabort.Click += new System.EventHandler(this.btnTabort_Click);
            // 
            // lbAvsnitt
            // 
            this.lbAvsnitt.FormattingEnabled = true;
            this.lbAvsnitt.ItemHeight = 20;
            this.lbAvsnitt.Location = new System.Drawing.Point(57, 472);
            this.lbAvsnitt.Name = "lbAvsnitt";
            this.lbAvsnitt.Size = new System.Drawing.Size(546, 144);
            this.lbAvsnitt.TabIndex = 10;
            this.lbAvsnitt.SelectedIndexChanged += new System.EventHandler(this.lbAvsnitt_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Avsnitt:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(676, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kategorier:";
            // 
            // lbKategorier
            // 
            this.lbKategorier.FormattingEnabled = true;
            this.lbKategorier.ItemHeight = 20;
            this.lbKategorier.Location = new System.Drawing.Point(681, 72);
            this.lbKategorier.Name = "lbKategorier";
            this.lbKategorier.Size = new System.Drawing.Size(278, 144);
            this.lbKategorier.TabIndex = 13;
            this.lbKategorier.SelectedIndexChanged += new System.EventHandler(this.lbKategorier_SelectedIndexChanged);
            // 
            // txtKategori
            // 
            this.txtKategori.Location = new System.Drawing.Point(681, 242);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(278, 26);
            this.txtKategori.TabIndex = 14;
            // 
            // btnNyKategori
            // 
            this.btnNyKategori.Location = new System.Drawing.Point(672, 297);
            this.btnNyKategori.Name = "btnNyKategori";
            this.btnNyKategori.Size = new System.Drawing.Size(84, 34);
            this.btnNyKategori.TabIndex = 15;
            this.btnNyKategori.Text = "Ny...";
            this.btnNyKategori.UseVisualStyleBackColor = true;
            this.btnNyKategori.Click += new System.EventHandler(this.btnNyKategori_Click);
            // 
            // btnSparaKategori
            // 
            this.btnSparaKategori.Location = new System.Drawing.Point(762, 297);
            this.btnSparaKategori.Name = "btnSparaKategori";
            this.btnSparaKategori.Size = new System.Drawing.Size(87, 34);
            this.btnSparaKategori.TabIndex = 16;
            this.btnSparaKategori.Text = "Spara";
            this.btnSparaKategori.UseVisualStyleBackColor = true;
            this.btnSparaKategori.Click += new System.EventHandler(this.btnSparaKategori_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(855, 297);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 34);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Ta bort...";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(677, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Beskrivning";
            // 
            // txtBeskrivning
            // 
            this.txtBeskrivning.Location = new System.Drawing.Point(680, 472);
            this.txtBeskrivning.Multiline = true;
            this.txtBeskrivning.Name = "txtBeskrivning";
            this.txtBeskrivning.Size = new System.Drawing.Size(241, 144);
            this.txtBeskrivning.TabIndex = 19;
            // 
            // Podcasts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 663);
            this.Controls.Add(this.txtBeskrivning);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSparaKategori);
            this.Controls.Add(this.btnNyKategori);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.lbKategorier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbAvsnitt);
            this.Controls.Add(this.btnTabort);
            this.Controls.Add(this.btnSpara);
            this.Controls.Add(this.btnNy);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.cbFrekvens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvPodcasts);
            this.Name = "Podcasts";
            this.Text = "Podcasts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvPodcasts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFrekvens;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Button btnNy;
        private System.Windows.Forms.Button btnSpara;
        private System.Windows.Forms.Button btnTabort;
        private System.Windows.Forms.ListBox lbAvsnitt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbKategorier;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.Button btnNyKategori;
        private System.Windows.Forms.Button btnSparaKategori;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ColumnHeader Avsnitt;
        public System.Windows.Forms.ColumnHeader Namn;
        public System.Windows.Forms.ColumnHeader Frekvens;
        public System.Windows.Forms.ColumnHeader Kategori;
        private System.Windows.Forms.TextBox txtBeskrivning;
    }
}

