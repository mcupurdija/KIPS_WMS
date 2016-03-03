namespace KIPS_WMS.UI.Ostalo
{
    partial class CsvImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvImport));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.lStatus = new System.Windows.Forms.Label();
            this.bLoad = new System.Windows.Forms.Button();
            this.bSelect = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lCustSyncDate = new System.Windows.Forms.Label();
            this.lItemSyncDate = new System.Windows.Forms.Label();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // lStatus
            // 
            this.lStatus.Location = new System.Drawing.Point(3, 57);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(233, 91);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(156, 30);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(80, 20);
            this.bLoad.TabIndex = 6;
            this.bLoad.Text = "Učitaj";
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bSelect
            // 
            this.bSelect.Location = new System.Drawing.Point(3, 30);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(80, 20);
            this.bSelect.TabIndex = 5;
            this.bSelect.Text = "Odaberi";
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // tbFile
            // 
            this.tbFile.Enabled = false;
            this.tbFile.Location = new System.Drawing.Point(3, 3);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(233, 21);
            this.tbFile.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lCustSyncDate
            // 
            this.lCustSyncDate.Location = new System.Drawing.Point(3, 148);
            this.lCustSyncDate.Name = "lCustSyncDate";
            this.lCustSyncDate.Size = new System.Drawing.Size(233, 20);
            // 
            // lItemSyncDate
            // 
            this.lItemSyncDate.Location = new System.Drawing.Point(3, 168);
            this.lItemSyncDate.Name = "lItemSyncDate";
            this.lItemSyncDate.Size = new System.Drawing.Size(233, 20);
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
            this.imageList1.ImageSize = new System.Drawing.Size(36, 70);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            // 
            // CsvImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.lItemSyncDate);
            this.Controls.Add(this.lCustSyncDate);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bSelect);
            this.Controls.Add(this.tbFile);
            this.MinimizeBox = false;
            this.Name = "CsvImport";
            this.Text = "Import";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button bSelect;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lCustSyncDate;
        private System.Windows.Forms.Label lItemSyncDate;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
    }
}