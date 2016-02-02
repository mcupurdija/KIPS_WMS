namespace KIPS_WMS.UI.Ostalo
{
    partial class ArtikliPoRegalimaDijalog
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
            this.bZatvori = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // bZatvori
            // 
            this.bZatvori.Location = new System.Drawing.Point(145, 117);
            this.bZatvori.Name = "bZatvori";
            this.bZatvori.Size = new System.Drawing.Size(72, 20);
            this.bZatvori.TabIndex = 0;
            this.bZatvori.Text = "Zatvori";
            this.bZatvori.Click += new System.EventHandler(this.bZatvori_Click);
            // 
            // listView1
            // 
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(214, 108);
            this.listView1.TabIndex = 1;
            // 
            // ArtikliPoRegalimaDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(220, 140);
            this.ControlBox = false;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bZatvori);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ArtikliPoRegalimaDijalog";
            this.Text = "Artikli po regalima";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bZatvori;
        private System.Windows.Forms.ListView listView1;
    }
}