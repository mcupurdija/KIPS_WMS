namespace KIPS_WMS.UI.Preklasifikacija
{
    partial class OdabirArtiklaDijalog
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
            this.bPotvrdi = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // bPotvrdi
            // 
            this.bPotvrdi.Location = new System.Drawing.Point(145, 117);
            this.bPotvrdi.Name = "bPotvrdi";
            this.bPotvrdi.Size = new System.Drawing.Size(72, 20);
            this.bPotvrdi.TabIndex = 0;
            this.bPotvrdi.Text = "Potvrdi";
            this.bPotvrdi.Click += new System.EventHandler(this.bPotvrdi_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(214, 108);
            this.listView1.TabIndex = 1;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // OdabirArtiklaDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CenterFormOnScreen = true;
            this.ClientSize = new System.Drawing.Size(220, 140);
            this.ControlBox = false;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bPotvrdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "OdabirArtiklaDijalog";
            this.Text = "Izaberite artikal";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OdabirArtiklaDijalog_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPotvrdi;
        private System.Windows.Forms.ListView listView1;

    }
}