namespace KIPS_WMS.UI.Izdvajanje
{
    partial class IzdvajanjePretragaPoDokumentu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzdvajanjePretragaPoDokumentu));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bNazad = new System.Windows.Forms.MenuItem();
            this.bDalje = new System.Windows.Forms.MenuItem();
            this.bPronadji = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.tbPronadji = new System.Windows.Forms.TextBox();
            this.listBox1 = new OpenNETCF.Windows.Forms.ListBox2();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bNazad);
            this.mainMenu1.MenuItems.Add(this.bDalje);
            // 
            // bNazad
            // 
            this.bNazad.Text = "Nazad";
            this.bNazad.Click += new System.EventHandler(this.bNazad_Click);
            // 
            // bDalje
            // 
            this.bDalje.Text = "Dalje";
            this.bDalje.Click += new System.EventHandler(this.bDalje_Click);
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(134, 3);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 20);
            this.bPronadji.TabIndex = 0;
            this.bPronadji.Text = "Pronađi";
            this.bPronadji.Click += new System.EventHandler(this.bPronadji_Click);
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(212, 3);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(25, 20);
            this.bReset.TabIndex = 1;
            this.bReset.Text = "X";
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // tbPronadji
            // 
            this.tbPronadji.Location = new System.Drawing.Point(3, 3);
            this.tbPronadji.Name = "tbPronadji";
            this.tbPronadji.Size = new System.Drawing.Size(125, 21);
            this.tbPronadji.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.BackgroundImage = null;
            this.listBox1.DataSource = null;
            this.listBox1.DisplayMember = null;
            this.listBox1.DrawMode = OpenNETCF.Windows.Forms.DrawMode.Normal;
            this.listBox1.EvenItemColor = System.Drawing.SystemColors.Control;
            this.listBox1.ImageList = null;
            this.listBox1.ItemHeight = 40;
            this.listBox1.LineColor = System.Drawing.SystemColors.ControlText;
            this.listBox1.Location = new System.Drawing.Point(0, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndex = -1;
            this.listBox1.ShowLines = true;
            this.listBox1.Size = new System.Drawing.Size(240, 158);
            this.listBox1.TabIndex = 3;
            this.listBox1.WrapText = false;
            this.listBox1.DrawItem += new OpenNETCF.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.toolBarButton1);
            this.toolBar1.Buttons.Add(this.toolBarButton2);
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(70, 36);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 1;
            // 
            // IzdvajanjePretragaPoDokumentu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbPronadji);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bPronadji);
            this.Name = "IzdvajanjePretragaPoDokumentu";
            this.Text = "Pretraga po dokumentu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.TextBox tbPronadji;
        private System.Windows.Forms.MenuItem bNazad;
        private System.Windows.Forms.MenuItem bDalje;
        private OpenNETCF.Windows.Forms.ListBox2 listBox1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ImageList imageList1;
    }
}