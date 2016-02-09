using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Isporuka
{
    partial class IsporukaDetalji
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
            this.bNazad = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.bPodeliRed = new System.Windows.Forms.MenuItem();
            this.bZameniRegal = new System.Windows.Forms.MenuItem();
            this.bDodaj = new System.Windows.Forms.Button();
            this.bZameni = new System.Windows.Forms.Button();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.tbBarkod = new System.Windows.Forms.TextBox();
            this.lJedinica = new System.Windows.Forms.Label();
            this.tbJedinicaKolicina = new System.Windows.Forms.TextBox();
            this.listBox1 = new OpenNETCF.Windows.Forms.ListBox2();
            this.tbRegal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bNazad);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // bNazad
            // 
            this.bNazad.Text = "Nazad";
            this.bNazad.Click += new System.EventHandler(this.bNazad_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.bPodeliRed);
            this.menuItem2.MenuItems.Add(this.bZameniRegal);
            this.menuItem2.Text = "Opcije";
            // 
            // bPodeliRed
            // 
            this.bPodeliRed.Text = "Podeli red";
            this.bPodeliRed.Click += new System.EventHandler(this.bPodeliRed_Click);
            // 
            // bZameniRegal
            // 
            this.bZameniRegal.Text = "Zameni regal";
            this.bZameniRegal.Click += new System.EventHandler(this.bZameniRegal_Click);
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(87, 164);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(72, 20);
            this.bDodaj.TabIndex = 0;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // bZameni
            // 
            this.bZameni.Location = new System.Drawing.Point(165, 164);
            this.bZameni.Name = "bZameni";
            this.bZameni.Size = new System.Drawing.Size(72, 20);
            this.bZameni.TabIndex = 1;
            this.bZameni.Text = "Zameni";
            this.bZameni.Click += new System.EventHandler(this.bZameni_Click);
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(3, 164);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(78, 21);
            this.tbKolicina.TabIndex = 2;
            this.tbKolicina.Text = "1";
            this.tbKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKolicina_KeyPress);
            // 
            // tbBarkod
            // 
            this.tbBarkod.Location = new System.Drawing.Point(3, 141);
            this.tbBarkod.Name = "tbBarkod";
            this.tbBarkod.Size = new System.Drawing.Size(110, 21);
            this.tbBarkod.TabIndex = 3;
            this.tbBarkod.TextChanged += new System.EventHandler(this.tbBarkod_TextChanged);
            this.tbBarkod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarkod_KeyUp);
            // 
            // lJedinica
            // 
            this.lJedinica.Location = new System.Drawing.Point(119, 141);
            this.lJedinica.Name = "lJedinica";
            this.lJedinica.Size = new System.Drawing.Size(52, 20);
            this.lJedinica.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbJedinicaKolicina
            // 
            this.tbJedinicaKolicina.Location = new System.Drawing.Point(177, 140);
            this.tbJedinicaKolicina.Name = "tbJedinicaKolicina";
            this.tbJedinicaKolicina.Size = new System.Drawing.Size(60, 21);
            this.tbJedinicaKolicina.TabIndex = 5;
            this.tbJedinicaKolicina.TextChanged += new System.EventHandler(this.tbJedinicaKolicina_TextChanged);
            this.tbJedinicaKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbJedinicaKolicina_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.BackgroundImage = null;
            this.listBox1.DataSource = null;
            this.listBox1.DisplayMember = null;
            this.listBox1.EvenItemColor = System.Drawing.SystemColors.Control;
            this.listBox1.ImageList = null;
            this.listBox1.ItemHeight = 21;
            this.listBox1.LineColor = System.Drawing.SystemColors.ControlText;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndex = -1;
            this.listBox1.ShowLines = true;
            this.listBox1.Size = new System.Drawing.Size(240, 111);
            this.listBox1.TabIndex = 6;
            this.listBox1.WrapText = false;
            this.listBox1.DrawItem += new OpenNETCF.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // tbRegal
            // 
            this.tbRegal.Location = new System.Drawing.Point(165, 116);
            this.tbRegal.Name = "tbRegal";
            this.tbRegal.Size = new System.Drawing.Size(72, 21);
            this.tbRegal.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(69, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.Text = "Bar kod regala:";
            // 
            // IsporukaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRegal);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbJedinicaKolicina);
            this.Controls.Add(this.lJedinica);
            this.Controls.Add(this.tbBarkod);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.bZameni);
            this.Controls.Add(this.bDodaj);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "IsporukaDetalji";
            this.Text = "PrijemDetalji";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem bNazad;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem bPodeliRed;
        private System.Windows.Forms.MenuItem bZameniRegal;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.Button bZameni;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.TextBox tbBarkod;
        private System.Windows.Forms.Label lJedinica;
        private System.Windows.Forms.TextBox tbJedinicaKolicina;
        private ListBox2 listBox1;
        private System.Windows.Forms.TextBox tbRegal;
        private System.Windows.Forms.Label label1;
    }
}