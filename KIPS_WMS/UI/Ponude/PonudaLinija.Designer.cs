namespace KIPS_WMS.UI.Ponude
{
    partial class PonudaLinija
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
            this.bOdustani = new System.Windows.Forms.MenuItem();
            this.bLagerLista = new System.Windows.Forms.MenuItem();
            this.bPrihvati = new System.Windows.Forms.MenuItem();
            this.lSifra = new System.Windows.Forms.Label();
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.lNaziv = new System.Windows.Forms.Label();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.tbKolicinaKonverzija = new System.Windows.Forms.TextBox();
            this.tbCena = new System.Windows.Forms.TextBox();
            this.tbCenaUkupno = new System.Windows.Forms.TextBox();
            this.tbKolicinaVezanaLokacija = new System.Windows.Forms.TextBox();
            this.tbRaspolozivoVezanaLokacija = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRaspolozivoLokacija = new System.Windows.Forms.TextBox();
            this.tbKolicinaLokacija = new System.Windows.Forms.TextBox();
            this.bUcitaj = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbJedinicaKonverzija = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCenaPopust = new System.Windows.Forms.TextBox();
            this.bJedinicaMere = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bOdustani);
            this.mainMenu1.MenuItems.Add(this.bLagerLista);
            this.mainMenu1.MenuItems.Add(this.bPrihvati);
            // 
            // bOdustani
            // 
            this.bOdustani.Text = "Odustani";
            this.bOdustani.Click += new System.EventHandler(this.bOdustani_Click);
            // 
            // bLagerLista
            // 
            this.bLagerLista.Text = "|   Lager lista";
            // 
            // bPrihvati
            // 
            this.bPrihvati.Text = "|   Prihvati";
            this.bPrihvati.Click += new System.EventHandler(this.bPrihvati_Click);
            // 
            // lSifra
            // 
            this.lSifra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lSifra.Location = new System.Drawing.Point(3, 5);
            this.lSifra.Name = "lSifra";
            this.lSifra.Size = new System.Drawing.Size(30, 17);
            this.lSifra.Text = "Šifra:";
            // 
            // tbSifra
            // 
            this.tbSifra.Enabled = false;
            this.tbSifra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbSifra.Location = new System.Drawing.Point(43, 3);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.Size = new System.Drawing.Size(194, 19);
            this.tbSifra.TabIndex = 3;
            // 
            // tbNaziv
            // 
            this.tbNaziv.Enabled = false;
            this.tbNaziv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbNaziv.Location = new System.Drawing.Point(43, 25);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(194, 19);
            this.tbNaziv.TabIndex = 5;
            // 
            // lNaziv
            // 
            this.lNaziv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lNaziv.Location = new System.Drawing.Point(3, 27);
            this.lNaziv.Name = "lNaziv";
            this.lNaziv.Size = new System.Drawing.Size(35, 17);
            this.lNaziv.Text = "Naziv:";
            // 
            // tbKolicina
            // 
            this.tbKolicina.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbKolicina.Location = new System.Drawing.Point(179, 51);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(58, 19);
            this.tbKolicina.TabIndex = 8;
            this.tbKolicina.TextChanged += new System.EventHandler(this.tbKolicina_TextChanged);
            // 
            // tbKolicinaKonverzija
            // 
            this.tbKolicinaKonverzija.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbKolicinaKonverzija.Location = new System.Drawing.Point(179, 73);
            this.tbKolicinaKonverzija.Name = "tbKolicinaKonverzija";
            this.tbKolicinaKonverzija.Size = new System.Drawing.Size(58, 19);
            this.tbKolicinaKonverzija.TabIndex = 9;
            // 
            // tbCena
            // 
            this.tbCena.Enabled = false;
            this.tbCena.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbCena.Location = new System.Drawing.Point(87, 96);
            this.tbCena.Name = "tbCena";
            this.tbCena.Size = new System.Drawing.Size(45, 19);
            this.tbCena.TabIndex = 13;
            // 
            // tbCenaUkupno
            // 
            this.tbCenaUkupno.Enabled = false;
            this.tbCenaUkupno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbCenaUkupno.Location = new System.Drawing.Point(119, 118);
            this.tbCenaUkupno.Name = "tbCenaUkupno";
            this.tbCenaUkupno.Size = new System.Drawing.Size(64, 19);
            this.tbCenaUkupno.TabIndex = 14;
            // 
            // tbKolicinaVezanaLokacija
            // 
            this.tbKolicinaVezanaLokacija.Enabled = false;
            this.tbKolicinaVezanaLokacija.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbKolicinaVezanaLokacija.Location = new System.Drawing.Point(179, 144);
            this.tbKolicinaVezanaLokacija.Name = "tbKolicinaVezanaLokacija";
            this.tbKolicinaVezanaLokacija.Size = new System.Drawing.Size(58, 19);
            this.tbKolicinaVezanaLokacija.TabIndex = 15;
            // 
            // tbRaspolozivoVezanaLokacija
            // 
            this.tbRaspolozivoVezanaLokacija.Enabled = false;
            this.tbRaspolozivoVezanaLokacija.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbRaspolozivoVezanaLokacija.Location = new System.Drawing.Point(179, 166);
            this.tbRaspolozivoVezanaLokacija.Name = "tbRaspolozivoVezanaLokacija";
            this.tbRaspolozivoVezanaLokacija.Size = new System.Drawing.Size(58, 19);
            this.tbRaspolozivoVezanaLokacija.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(118, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.Text = "Uk. v. lok.:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(118, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.Text = "Ra. v. lok.:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.Text = "Ra. lok.:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.Text = "Uk. lok.:";
            // 
            // tbRaspolozivoLokacija
            // 
            this.tbRaspolozivoLokacija.Enabled = false;
            this.tbRaspolozivoLokacija.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbRaspolozivoLokacija.Location = new System.Drawing.Point(54, 166);
            this.tbRaspolozivoLokacija.Name = "tbRaspolozivoLokacija";
            this.tbRaspolozivoLokacija.Size = new System.Drawing.Size(58, 19);
            this.tbRaspolozivoLokacija.TabIndex = 24;
            // 
            // tbKolicinaLokacija
            // 
            this.tbKolicinaLokacija.Enabled = false;
            this.tbKolicinaLokacija.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbKolicinaLokacija.Location = new System.Drawing.Point(54, 144);
            this.tbKolicinaLokacija.Name = "tbKolicinaLokacija";
            this.tbKolicinaLokacija.Size = new System.Drawing.Size(58, 19);
            this.tbKolicinaLokacija.TabIndex = 23;
            // 
            // bUcitaj
            // 
            this.bUcitaj.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bUcitaj.Location = new System.Drawing.Point(189, 96);
            this.bUcitaj.Name = "bUcitaj";
            this.bUcitaj.Size = new System.Drawing.Size(48, 41);
            this.bUcitaj.TabIndex = 27;
            this.bUcitaj.Text = "Učitaj\r\ncenu";
            this.bUcitaj.Click += new System.EventHandler(this.bUcitaj_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.Text = "MPC/Sa popus.:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.Text = "Ukupno sa popustom:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(3, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.Text = "JM kon.:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(28, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 17);
            this.label8.Text = "JM:";
            // 
            // tbJedinicaKonverzija
            // 
            this.tbJedinicaKonverzija.Enabled = false;
            this.tbJedinicaKonverzija.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbJedinicaKonverzija.Location = new System.Drawing.Point(54, 73);
            this.tbJedinicaKonverzija.Name = "tbJedinicaKonverzija";
            this.tbJedinicaKonverzija.Size = new System.Drawing.Size(58, 19);
            this.tbJedinicaKonverzija.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(127, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.Text = "Količina:";
            // 
            // tbCenaPopust
            // 
            this.tbCenaPopust.Enabled = false;
            this.tbCenaPopust.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbCenaPopust.Location = new System.Drawing.Point(138, 96);
            this.tbCenaPopust.Name = "tbCenaPopust";
            this.tbCenaPopust.Size = new System.Drawing.Size(45, 19);
            this.tbCenaPopust.TabIndex = 52;
            // 
            // bJedinicaMere
            // 
            this.bJedinicaMere.Location = new System.Drawing.Point(54, 51);
            this.bJedinicaMere.Name = "bJedinicaMere";
            this.bJedinicaMere.Size = new System.Drawing.Size(58, 19);
            this.bJedinicaMere.TabIndex = 64;
            this.bJedinicaMere.Click += new System.EventHandler(this.bJedinicaMere_Click);
            // 
            // PonudaLinija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.bJedinicaMere);
            this.Controls.Add(this.tbCenaPopust);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbJedinicaKonverzija);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bUcitaj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRaspolozivoLokacija);
            this.Controls.Add(this.tbKolicinaLokacija);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRaspolozivoVezanaLokacija);
            this.Controls.Add(this.tbKolicinaVezanaLokacija);
            this.Controls.Add(this.tbCenaUkupno);
            this.Controls.Add(this.tbCena);
            this.Controls.Add(this.tbKolicinaKonverzija);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.lNaziv);
            this.Controls.Add(this.tbNaziv);
            this.Controls.Add(this.tbSifra);
            this.Controls.Add(this.lSifra);
            this.Menu = this.mainMenu1;
            this.Name = "PonudaLinija";
            this.Text = "Nova ponuda";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lSifra;
        private System.Windows.Forms.TextBox tbSifra;
        private System.Windows.Forms.TextBox tbNaziv;
        private System.Windows.Forms.Label lNaziv;
        private System.Windows.Forms.MenuItem bOdustani;
        private System.Windows.Forms.MenuItem bLagerLista;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.TextBox tbKolicinaKonverzija;
        private System.Windows.Forms.MenuItem bPrihvati;
        private System.Windows.Forms.TextBox tbCena;
        private System.Windows.Forms.TextBox tbCenaUkupno;
        private System.Windows.Forms.TextBox tbKolicinaVezanaLokacija;
        private System.Windows.Forms.TextBox tbRaspolozivoVezanaLokacija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRaspolozivoLokacija;
        private System.Windows.Forms.TextBox tbKolicinaLokacija;
        private System.Windows.Forms.Button bUcitaj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbJedinicaKonverzija;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCenaPopust;
        private System.Windows.Forms.Button bJedinicaMere;
    }
}