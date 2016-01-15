namespace KIPS_WMS.UI.Ponude
{
    partial class NovaPonuda
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
            this.bNoviKupci = new System.Windows.Forms.MenuItem();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.bNepoznatKupac = new System.Windows.Forms.Button();
            this.bKreiraj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bNoviKupci);
            // 
            // bNoviKupci
            // 
            this.bNoviKupci.Text = "Novi kupci";
            this.bNoviKupci.Click += new System.EventHandler(this.bNoviKupci_Click);
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(3, 3);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(156, 21);
            this.tbPronadji.TabIndex = 0;
            this.tbPronadji.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPronadji_KeyUp);
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(165, 3);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 21);
            this.bPronadji.TabIndex = 1;
            this.bPronadji.Text = "Pronadji";
            this.bPronadji.Click += new System.EventHandler(this.bPronadji_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 127);
            this.listView1.TabIndex = 4;
            // 
            // bNepoznatKupac
            // 
            this.bNepoznatKupac.Location = new System.Drawing.Point(3, 164);
            this.bNepoznatKupac.Name = "bNepoznatKupac";
            this.bNepoznatKupac.Size = new System.Drawing.Size(114, 21);
            this.bNepoznatKupac.TabIndex = 5;
            this.bNepoznatKupac.Text = "Nepoznat kupac";
            this.bNepoznatKupac.Click += new System.EventHandler(this.bNepoznatKupac_Click);
            // 
            // bKreiraj
            // 
            this.bKreiraj.Location = new System.Drawing.Point(123, 164);
            this.bKreiraj.Name = "bKreiraj";
            this.bKreiraj.Size = new System.Drawing.Size(114, 21);
            this.bKreiraj.TabIndex = 6;
            this.bKreiraj.Text = "Kreiraj";
            this.bKreiraj.Click += new System.EventHandler(this.bKreiraj_Click);
            // 
            // NovaPonuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.bKreiraj);
            this.Controls.Add(this.bNepoznatKupac);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbPronadji);
            this.Menu = this.mainMenu1;
            this.Name = "NovaPonuda";
            this.Text = "Nova ponuda";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NovaPonuda_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbPronadji;
        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuItem bNoviKupci;
        private System.Windows.Forms.Button bNepoznatKupac;
        private System.Windows.Forms.Button bKreiraj;
    }
}