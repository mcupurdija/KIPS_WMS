namespace KIPS_WMS.UI.Preklasifikacija
{
    partial class Pracenje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bObrisi = new System.Windows.Forms.MenuItem();
            this.bDalje = new System.Windows.Forms.MenuItem();
            this.lSifra = new System.Windows.Forms.Label();
            this.lTekst = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSN = new System.Windows.Forms.TextBox();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.bDodaj = new System.Windows.Forms.Button();
            this.lKolicina = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dtDatum = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bObrisi);
            this.mainMenu1.MenuItems.Add(this.bDalje);
            // 
            // bObrisi
            // 
            this.bObrisi.Text = "Obriši";
            this.bObrisi.Click += new System.EventHandler(this.bObrisi_Click);
            // 
            // bDalje
            // 
            this.bDalje.Text = "Dalje";
            this.bDalje.Click += new System.EventHandler(this.bDalje_Click);
            // 
            // lSifra
            // 
            this.lSifra.Location = new System.Drawing.Point(4, 4);
            this.lSifra.Name = "lSifra";
            this.lSifra.Size = new System.Drawing.Size(233, 20);
            this.lSifra.Text = "Šifra artikla: ";
            // 
            // lTekst
            // 
            this.lTekst.Location = new System.Drawing.Point(4, 28);
            this.lTekst.Name = "lTekst";
            this.lTekst.Size = new System.Drawing.Size(57, 20);
            this.lTekst.Text = "SN:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.Text = "Količina:";
            // 
            // tbSN
            // 
            this.tbSN.Location = new System.Drawing.Point(67, 27);
            this.tbSN.Name = "tbSN";
            this.tbSN.Size = new System.Drawing.Size(70, 21);
            this.tbSN.TabIndex = 4;
            this.tbSN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSN_KeyUp);
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(67, 47);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(70, 21);
            this.tbKolicina.TabIndex = 8;
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(150, 48);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(84, 21);
            this.bDodaj.TabIndex = 9;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // lKolicina
            // 
            this.lKolicina.Location = new System.Drawing.Point(67, 75);
            this.lKolicina.Name = "lKolicina";
            this.lKolicina.Size = new System.Drawing.Size(70, 20);
            this.lKolicina.Text = "kolicina";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(4, 102);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(230, 86);
            this.listView1.TabIndex = 11;
            // 
            // dtDatum
            // 
            this.dtDatum.CustomFormat = "dd.MM.yyyy.";
            this.dtDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDatum.Location = new System.Drawing.Point(143, 26);
            this.dtDatum.Name = "dtDatum";
            this.dtDatum.Size = new System.Drawing.Size(91, 22);
            this.dtDatum.TabIndex = 16;
            // 
            // Pracenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.ControlBox = false;
            this.Controls.Add(this.dtDatum);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lKolicina);
            this.Controls.Add(this.bDodaj);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.tbSN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lTekst);
            this.Controls.Add(this.lSifra);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Pracenje";
            this.Text = "Praćenje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lSifra;
        private System.Windows.Forms.Label lTekst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSN;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.MenuItem bObrisi;
        private System.Windows.Forms.MenuItem bDalje;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.Label lKolicina;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dtDatum;
    }
}