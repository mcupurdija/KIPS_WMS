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
            this.bNepoznatKupac = new System.Windows.Forms.MenuItem();
            this.bNoviKupci = new System.Windows.Forms.MenuItem();
            this.bKreiraj = new System.Windows.Forms.MenuItem();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bNepoznatKupac);
            this.mainMenu1.MenuItems.Add(this.bNoviKupci);
            this.mainMenu1.MenuItems.Add(this.bKreiraj);
            // 
            // bNepoznatKupac
            // 
            this.bNepoznatKupac.Text = "Nepoznat kupac";
            // 
            // bNoviKupci
            // 
            this.bNoviKupci.Text = "|   Novi kupci";
            // 
            // bKreiraj
            // 
            this.bKreiraj.Text = "|   Kreiraj";
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(3, 3);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(156, 21);
            this.tbPronadji.TabIndex = 0;
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(165, 3);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 21);
            this.bPronadji.TabIndex = 1;
            this.bPronadji.Text = "Pronadji";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 154);
            this.listView1.TabIndex = 4;
            // 
            // NovaPonuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
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
        private System.Windows.Forms.MenuItem bNepoznatKupac;
        private System.Windows.Forms.MenuItem bNoviKupci;
        private System.Windows.Forms.MenuItem bKreiraj;
    }
}