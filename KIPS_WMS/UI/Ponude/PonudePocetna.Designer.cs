namespace KIPS_WMS.UI.Ponude
{
    partial class PonudePocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PonudePocetna));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tbUcitaj = new System.Windows.Forms.TextBox();
            this.bUcitaj = new System.Windows.Forms.Button();
            this.bNova = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // tbUcitaj
            // 
            this.tbUcitaj.Location = new System.Drawing.Point(3, 3);
            this.tbUcitaj.Name = "tbUcitaj";
            this.tbUcitaj.Size = new System.Drawing.Size(156, 21);
            this.tbUcitaj.TabIndex = 0;
            this.tbUcitaj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbUcitaj_KeyUp);
            // 
            // bUcitaj
            // 
            this.bUcitaj.Location = new System.Drawing.Point(165, 3);
            this.bUcitaj.Name = "bUcitaj";
            this.bUcitaj.Size = new System.Drawing.Size(72, 20);
            this.bUcitaj.TabIndex = 1;
            this.bUcitaj.Text = "Učitaj";
            this.bUcitaj.Click += new System.EventHandler(this.bUcitaj_Click);
            // 
            // bNova
            // 
            this.bNova.Location = new System.Drawing.Point(3, 30);
            this.bNova.Name = "bNova";
            this.bNova.Size = new System.Drawing.Size(110, 40);
            this.bNova.TabIndex = 2;
            this.bNova.Text = "Nova";
            this.bNova.Click += new System.EventHandler(this.bNova_Click);
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
            // PonudePocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.bNova);
            this.Controls.Add(this.bUcitaj);
            this.Controls.Add(this.tbUcitaj);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "PonudePocetna";
            this.Text = "Ponude";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PonudePocetna_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbUcitaj;
        private System.Windows.Forms.Button bUcitaj;
        private System.Windows.Forms.Button bNova;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
    }
}