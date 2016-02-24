namespace KIPS_WMS.UI
{
    partial class LagerLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LagerLista));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.bPronadji = new System.Windows.Forms.Button();
            this.lvLagerLista = new System.Windows.Forms.ListView();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // tbSifra
            // 
            this.tbSifra.Location = new System.Drawing.Point(3, 3);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.Size = new System.Drawing.Size(156, 21);
            this.tbSifra.TabIndex = 0;
            this.tbSifra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSifra_KeyUp);
            // 
            // bPronadji
            // 
            this.bPronadji.Location = new System.Drawing.Point(165, 3);
            this.bPronadji.Name = "bPronadji";
            this.bPronadji.Size = new System.Drawing.Size(72, 20);
            this.bPronadji.TabIndex = 1;
            this.bPronadji.Text = "Pronadji";
            this.bPronadji.Click += new System.EventHandler(this.bPronadji_Click);
            // 
            // lvLagerLista
            // 
            this.lvLagerLista.FullRowSelect = true;
            this.lvLagerLista.Location = new System.Drawing.Point(0, 30);
            this.lvLagerLista.Name = "lvLagerLista";
            this.lvLagerLista.Size = new System.Drawing.Size(240, 158);
            this.lvLagerLista.TabIndex = 2;
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
            // LagerLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.lvLagerLista);
            this.Controls.Add(this.bPronadji);
            this.Controls.Add(this.tbSifra);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "LagerLista";
            this.Text = "Lager lista";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LagerLista_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbSifra;
        private System.Windows.Forms.Button bPronadji;
        private System.Windows.Forms.ListView lvLagerLista;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ImageList imageList1;
    }
}