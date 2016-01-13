namespace KIPS_WMS.UI.Ponude
{
    partial class PonudaKorpa
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
            this.bOpcije = new System.Windows.Forms.MenuItem();
            this.bIzmeni = new System.Windows.Forms.MenuItem();
            this.bObrisi = new System.Windows.Forms.MenuItem();
            this.bUcitajNoveArtikle = new System.Windows.Forms.MenuItem();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.bResetuj = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.bPosalji = new System.Windows.Forms.MenuItem();
            this.bDodaj = new System.Windows.Forms.MenuItem();
            this.lKupac = new System.Windows.Forms.Label();
            this.lUkupno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bOpcije);
            this.mainMenu1.MenuItems.Add(this.bPosalji);
            this.mainMenu1.MenuItems.Add(this.bDodaj);
            // 
            // bOpcije
            // 
            this.bOpcije.MenuItems.Add(this.bIzmeni);
            this.bOpcije.MenuItems.Add(this.bObrisi);
            this.bOpcije.MenuItems.Add(this.bUcitajNoveArtikle);
            this.bOpcije.Text = "Opcije";
            // 
            // bIzmeni
            // 
            this.bIzmeni.Text = "Izmeni liniju";
            // 
            // bObrisi
            // 
            this.bObrisi.Text = "Obriši liniju";
            // 
            // bUcitajNoveArtikle
            // 
            this.bUcitajNoveArtikle.Text = "Učitaj nove artikle";
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(3, 24);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(125, 21);
            this.tbPronadji.TabIndex = 0;
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(134, 24);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 21);
            this.bPronadji.TabIndex = 1;
            this.bPronadji.Text = "Pronađi";
            // 
            // bResetuj
            // 
            this.bResetuj.Location = new System.Drawing.Point(212, 24);
            this.bResetuj.Name = "bResetuj";
            this.bResetuj.Size = new System.Drawing.Size(25, 21);
            this.bResetuj.TabIndex = 2;
            this.bResetuj.Text = "X";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 51);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 134);
            this.listView1.TabIndex = 5;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // bPosalji
            // 
            this.bPosalji.Text = "|   Pošalji";
            // 
            // bDodaj
            // 
            this.bDodaj.Text = "|   Dodaj";
            // 
            // lKupac
            // 
            this.lKupac.Location = new System.Drawing.Point(4, 4);
            this.lKupac.Name = "lKupac";
            this.lKupac.Size = new System.Drawing.Size(134, 20);
            this.lKupac.Text = "Kupac";
            // 
            // lUkupno
            // 
            this.lUkupno.Location = new System.Drawing.Point(144, 4);
            this.lUkupno.Name = "lUkupno";
            this.lUkupno.Size = new System.Drawing.Size(93, 20);
            this.lUkupno.Text = "Ukupno: 123,45";
            this.lUkupno.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PonudaKorpa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.lUkupno);
            this.Controls.Add(this.lKupac);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bResetuj);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbPronadji);
            this.Menu = this.mainMenu1;
            this.Name = "PonudaKorpa";
            this.Text = "Ponuda 123";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem bOpcije;
        private System.Windows.Forms.TextBox tbPronadji;
        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.Button bResetuj;
        private System.Windows.Forms.MenuItem bIzmeni;
        private System.Windows.Forms.MenuItem bObrisi;
        private System.Windows.Forms.MenuItem bUcitajNoveArtikle;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuItem bPosalji;
        private System.Windows.Forms.MenuItem bDodaj;
        private System.Windows.Forms.Label lKupac;
        private System.Windows.Forms.Label lUkupno;
    }
}