namespace KIPS_WMS.UI.Ostalo
{
    partial class OdabirMagacina
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.bDalje = new System.Windows.Forms.Button();
            this.bOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(173, 87);
            this.listView1.TabIndex = 0;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // bDalje
            // 
            this.bDalje.Location = new System.Drawing.Point(105, 97);
            this.bDalje.Name = "bDalje";
            this.bDalje.Size = new System.Drawing.Size(72, 20);
            this.bDalje.TabIndex = 1;
            this.bDalje.Text = "Dalje";
            this.bDalje.Click += new System.EventHandler(this.bDalje_Click);
            // 
            // bOdustani
            // 
            this.bOdustani.Location = new System.Drawing.Point(4, 97);
            this.bOdustani.Name = "bOdustani";
            this.bOdustani.Size = new System.Drawing.Size(72, 20);
            this.bOdustani.TabIndex = 2;
            this.bOdustani.Text = "Odustani";
            this.bOdustani.Click += new System.EventHandler(this.bOdustani_Click);
            // 
            // OdabirMagacina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(180, 120);
            this.ControlBox = false;
            this.Controls.Add(this.bOdustani);
            this.Controls.Add(this.bDalje);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "OdabirMagacina";
            this.Text = "Izaberite magacin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button bDalje;
        private System.Windows.Forms.Button bOdustani;
    }
}