namespace KIPS_WMS.UI.Prijem
{
    partial class PrijemPocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrijemPocetna));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bDokument = new System.Windows.Forms.Button();
            this.bArtikal = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // bDokument
            // 
            this.bDokument.Location = new System.Drawing.Point(3, 4);
            this.bDokument.Name = "bDokument";
            this.bDokument.Size = new System.Drawing.Size(234, 40);
            this.bDokument.TabIndex = 0;
            this.bDokument.Text = "Pretraga po dokumentu";
            this.bDokument.Click += new System.EventHandler(this.bDokument_Click);
            // 
            // bArtikal
            // 
            this.bArtikal.Location = new System.Drawing.Point(3, 50);
            this.bArtikal.Name = "bArtikal";
            this.bArtikal.Size = new System.Drawing.Size(234, 40);
            this.bArtikal.TabIndex = 1;
            this.bArtikal.Text = "Pretraga po artiklu";
            this.bArtikal.Click += new System.EventHandler(this.bArtikal_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.toolBarButton1);
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(70, 36);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // PrijemPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.bArtikal);
            this.Controls.Add(this.bDokument);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "PrijemPocetna";
            this.Text = "Prijem";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrijemPocetna_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDokument;
        private System.Windows.Forms.Button bArtikal;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ImageList imageList1;
    }
}