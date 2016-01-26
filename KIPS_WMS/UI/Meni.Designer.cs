namespace KIPS_WMS.UI
{
    partial class Meni
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.bUnosBarkoda = new System.Windows.Forms.MenuItem();
            this.bCrossDocking = new System.Windows.Forms.MenuItem();
            this.bUvozPodataka = new System.Windows.Forms.MenuItem();
            this.bPodesavanja = new System.Windows.Forms.MenuItem();
            this.bPonude = new System.Windows.Forms.Button();
            this.bPreklasifikacija = new System.Windows.Forms.Button();
            this.bMagPrijemnice = new System.Windows.Forms.Button();
            this.bMagIsporuke = new System.Windows.Forms.Button();
            this.bSkladistenja = new System.Windows.Forms.Button();
            this.bIzdvajanja = new System.Windows.Forms.Button();
            this.bBarkodTest = new System.Windows.Forms.Button();
            this.bKontrolnaCena = new System.Windows.Forms.Button();
            this.bLagerLista = new System.Windows.Forms.Button();
            this.bPopis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.bUnosBarkoda);
            this.menuItem1.MenuItems.Add(this.bCrossDocking);
            this.menuItem1.MenuItems.Add(this.bUvozPodataka);
            this.menuItem1.MenuItems.Add(this.bPodesavanja);
            this.menuItem1.Text = "Ostalo";
            // 
            // bUnosBarkoda
            // 
            this.bUnosBarkoda.Text = "Unos barkoda";
            // 
            // bCrossDocking
            // 
            this.bCrossDocking.Text = "Cross docking";
            // 
            // bUvozPodataka
            // 
            this.bUvozPodataka.Text = "Uvoz podataka";
            this.bUvozPodataka.Click += new System.EventHandler(this.bUvozPodataka_Click);
            // 
            // bPodesavanja
            // 
            this.bPodesavanja.Text = "Podešavanja";
            this.bPodesavanja.Click += new System.EventHandler(this.bPodesavanja_Click);
            // 
            // bPonude
            // 
            this.bPonude.Location = new System.Drawing.Point(3, 3);
            this.bPonude.Name = "bPonude";
            this.bPonude.Size = new System.Drawing.Size(114, 30);
            this.bPonude.TabIndex = 0;
            this.bPonude.Text = "Ponude";
            this.bPonude.Click += new System.EventHandler(this.bPonude_Click);
            // 
            // bPreklasifikacija
            // 
            this.bPreklasifikacija.Location = new System.Drawing.Point(123, 3);
            this.bPreklasifikacija.Name = "bPreklasifikacija";
            this.bPreklasifikacija.Size = new System.Drawing.Size(114, 30);
            this.bPreklasifikacija.TabIndex = 1;
            this.bPreklasifikacija.Text = "Preklasifikacija";
            this.bPreklasifikacija.Click += new System.EventHandler(this.bPreklasifikacija_Click);
            // 
            // bMagPrijemnice
            // 
            this.bMagPrijemnice.Location = new System.Drawing.Point(3, 39);
            this.bMagPrijemnice.Name = "bMagPrijemnice";
            this.bMagPrijemnice.Size = new System.Drawing.Size(114, 30);
            this.bMagPrijemnice.TabIndex = 2;
            this.bMagPrijemnice.Text = "Mag. prijemnice";
            this.bMagPrijemnice.Click += new System.EventHandler(this.bMagPrijemnice_Click);
            // 
            // bMagIsporuke
            // 
            this.bMagIsporuke.Location = new System.Drawing.Point(123, 39);
            this.bMagIsporuke.Name = "bMagIsporuke";
            this.bMagIsporuke.Size = new System.Drawing.Size(114, 30);
            this.bMagIsporuke.TabIndex = 3;
            this.bMagIsporuke.Text = "Mag. isporuke";
            // 
            // bSkladistenja
            // 
            this.bSkladistenja.Location = new System.Drawing.Point(3, 75);
            this.bSkladistenja.Name = "bSkladistenja";
            this.bSkladistenja.Size = new System.Drawing.Size(114, 30);
            this.bSkladistenja.TabIndex = 4;
            this.bSkladistenja.Text = "Skladištenja";
            this.bSkladistenja.Click += new System.EventHandler(this.bSkladistenja_Click);
            // 
            // bIzdvajanja
            // 
            this.bIzdvajanja.Location = new System.Drawing.Point(123, 75);
            this.bIzdvajanja.Name = "bIzdvajanja";
            this.bIzdvajanja.Size = new System.Drawing.Size(114, 30);
            this.bIzdvajanja.TabIndex = 5;
            this.bIzdvajanja.Text = "Izdvajanja";
            this.bIzdvajanja.Click += new System.EventHandler(this.bIzdvajanja_Click);
            // 
            // bBarkodTest
            // 
            this.bBarkodTest.Location = new System.Drawing.Point(3, 111);
            this.bBarkodTest.Name = "bBarkodTest";
            this.bBarkodTest.Size = new System.Drawing.Size(114, 30);
            this.bBarkodTest.TabIndex = 6;
            this.bBarkodTest.Text = "Barkod test";
            // 
            // bKontrolnaCena
            // 
            this.bKontrolnaCena.Location = new System.Drawing.Point(123, 111);
            this.bKontrolnaCena.Name = "bKontrolnaCena";
            this.bKontrolnaCena.Size = new System.Drawing.Size(114, 30);
            this.bKontrolnaCena.TabIndex = 7;
            this.bKontrolnaCena.Text = "Kontrolna cijena";
            // 
            // bLagerLista
            // 
            this.bLagerLista.Location = new System.Drawing.Point(3, 147);
            this.bLagerLista.Name = "bLagerLista";
            this.bLagerLista.Size = new System.Drawing.Size(114, 30);
            this.bLagerLista.TabIndex = 8;
            this.bLagerLista.Text = "Lager lista";
            this.bLagerLista.Click += new System.EventHandler(this.bLagerLista_Click);
            // 
            // bPopis
            // 
            this.bPopis.Location = new System.Drawing.Point(123, 147);
            this.bPopis.Name = "bPopis";
            this.bPopis.Size = new System.Drawing.Size(114, 30);
            this.bPopis.TabIndex = 9;
            this.bPopis.Text = "Popis";
            this.bPopis.Click += new System.EventHandler(this.bPopis_Click);
            // 
            // Meni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.bPopis);
            this.Controls.Add(this.bLagerLista);
            this.Controls.Add(this.bKontrolnaCena);
            this.Controls.Add(this.bBarkodTest);
            this.Controls.Add(this.bIzdvajanja);
            this.Controls.Add(this.bSkladistenja);
            this.Controls.Add(this.bMagIsporuke);
            this.Controls.Add(this.bMagPrijemnice);
            this.Controls.Add(this.bPreklasifikacija);
            this.Controls.Add(this.bPonude);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Meni";
            this.Text = "Meni";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPonude;
        private System.Windows.Forms.Button bPreklasifikacija;
        private System.Windows.Forms.Button bMagPrijemnice;
        private System.Windows.Forms.Button bMagIsporuke;
        private System.Windows.Forms.Button bSkladistenja;
        private System.Windows.Forms.Button bIzdvajanja;
        private System.Windows.Forms.Button bBarkodTest;
        private System.Windows.Forms.Button bKontrolnaCena;
        private System.Windows.Forms.Button bLagerLista;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Button bPopis;
        private System.Windows.Forms.MenuItem bUnosBarkoda;
        private System.Windows.Forms.MenuItem bCrossDocking;
        private System.Windows.Forms.MenuItem bPodesavanja;
        private System.Windows.Forms.MenuItem bUvozPodataka;
    }
}