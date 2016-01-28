using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Prijem
{
    partial class PrijemDetalji
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
            this.bArtikalPoRegalima = new System.Windows.Forms.MenuItem();
            this.bPodeliRed = new System.Windows.Forms.MenuItem();
            this.bZameniRegal = new System.Windows.Forms.MenuItem();
            this.bOsteceno = new System.Windows.Forms.MenuItem();
            this.bDodaj = new System.Windows.Forms.Button();
            this.bZameni = new System.Windows.Forms.Button();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new OpenNETCF.Windows.Forms.ListBox2();
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
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.bArtikalPoRegalima);
            this.menuItem2.MenuItems.Add(this.bPodeliRed);
            this.menuItem2.MenuItems.Add(this.bZameniRegal);
            this.menuItem2.MenuItems.Add(this.bOsteceno);
            this.menuItem2.Text = "Opcije";
            // 
            // bArtikalPoRegalima
            // 
            this.bArtikalPoRegalima.Text = "Artikal po regalima";
            // 
            // bPodeliRed
            // 
            this.bPodeliRed.Text = "Podeli red";
            // 
            // bZameniRegal
            // 
            this.bZameniRegal.Text = "Zameni regal";
            // 
            // bOsteceno
            // 
            this.bOsteceno.Text = "Oštećeno/Nekompletno";
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(87, 164);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(72, 20);
            this.bDodaj.TabIndex = 0;
            this.bDodaj.Text = "Dodaj";
            // 
            // bZameni
            // 
            this.bZameni.Location = new System.Drawing.Point(165, 164);
            this.bZameni.Name = "bZameni";
            this.bZameni.Size = new System.Drawing.Size(72, 20);
            this.bZameni.TabIndex = 1;
            this.bZameni.Text = "Zameni";
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(3, 164);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(78, 21);
            this.tbKolicina.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(119, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.Text = "PAK";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(151, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(50, 21);
            this.textBox2.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.BackgroundImage = null;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.ShowLines = true;
            this.listBox1.Size = new System.Drawing.Size(240, 111);
            this.listBox1.TabIndex = 6;
            // 
            // PrijemDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.bZameni);
            this.Controls.Add(this.bDodaj);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "PrijemDetalji";
            this.Text = "PrijemDetalji";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem bNazad;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem bArtikalPoRegalima;
        private System.Windows.Forms.MenuItem bPodeliRed;
        private System.Windows.Forms.MenuItem bZameniRegal;
        private System.Windows.Forms.MenuItem bOsteceno;
        private System.Windows.Forms.Button bDodaj;
        private System.Windows.Forms.Button bZameni;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private ListBox2 listBox1;
    }
}