﻿namespace KIPS_WMS.UI.Isporuka
{
    partial class IsporukaPocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsporukaPocetna));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bDokument = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
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
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.toolBarButton1);
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(70, 36);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            // 
            // IsporukaPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.bDokument);
            this.MinimizeBox = false;
            this.Name = "IsporukaPocetna";
            this.Text = "Isporuke";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDokument;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
    }
}