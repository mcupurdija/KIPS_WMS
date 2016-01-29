﻿using OpenNETCF.Windows.Forms;

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
            this.tbBarkod = new System.Windows.Forms.TextBox();
            this.lJedinica = new System.Windows.Forms.Label();
            this.tbJedinicaKolicina = new System.Windows.Forms.TextBox();
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
            this.bDodaj.Location = new System.Drawing.Point(87, 144);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(72, 20);
            this.bDodaj.TabIndex = 0;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // bZameni
            // 
            this.bZameni.Location = new System.Drawing.Point(165, 144);
            this.bZameni.Name = "bZameni";
            this.bZameni.Size = new System.Drawing.Size(72, 20);
            this.bZameni.TabIndex = 1;
            this.bZameni.Text = "Zameni";
            this.bZameni.Click += new System.EventHandler(this.bZameni_Click);
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(3, 144);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(78, 21);
            this.tbKolicina.TabIndex = 2;
            this.tbKolicina.Text = "1";
            // 
            // tbBarkod
            // 
            this.tbBarkod.Location = new System.Drawing.Point(3, 117);
            this.tbBarkod.Name = "tbBarkod";
            this.tbBarkod.Size = new System.Drawing.Size(110, 21);
            this.tbBarkod.TabIndex = 3;
            this.tbBarkod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarkod_KeyUp);
            // 
            // lJedinica
            // 
            this.lJedinica.Location = new System.Drawing.Point(119, 118);
            this.lJedinica.Name = "lJedinica";
            this.lJedinica.Size = new System.Drawing.Size(26, 20);
            this.lJedinica.Text = "PAK";
            // 
            // tbJedinicaKolicina
            // 
            this.tbJedinicaKolicina.Location = new System.Drawing.Point(151, 117);
            this.tbJedinicaKolicina.Name = "tbJedinicaKolicina";
            this.tbJedinicaKolicina.Size = new System.Drawing.Size(86, 21);
            this.tbJedinicaKolicina.TabIndex = 5;
            this.tbJedinicaKolicina.TextChanged += new System.EventHandler(this.tbJedinicaKolicina_TextChanged);
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
            // PrijemDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbJedinicaKolicina);
            this.Controls.Add(this.lJedinica);
            this.Controls.Add(this.tbBarkod);
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
        private System.Windows.Forms.TextBox tbBarkod;
        private System.Windows.Forms.Label lJedinica;
        private System.Windows.Forms.TextBox tbJedinicaKolicina;
        private ListBox2 listBox1;
    }
}