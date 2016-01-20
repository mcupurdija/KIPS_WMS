﻿namespace KIPS_WMS.UI
{
    partial class Settings
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
            this.bSacuvaj = new System.Windows.Forms.MenuItem();
            this.cbPrinters = new System.Windows.Forms.ComboBox();
            this.tbSavedPrinter = new System.Windows.Forms.TextBox();
            this.bShort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.bSacuvaj);
            // 
            // bSacuvaj
            // 
            this.bSacuvaj.Text = "Sačuvaj";
            this.bSacuvaj.Click += new System.EventHandler(this.bSacuvaj_Click);
            // 
            // cbPrinters
            // 
            this.cbPrinters.Location = new System.Drawing.Point(3, 27);
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(234, 22);
            this.cbPrinters.TabIndex = 0;
            this.cbPrinters.SelectedIndexChanged += new System.EventHandler(this.cbPrinters_SelectedIndexChanged);
            // 
            // tbSavedPrinter
            // 
            this.tbSavedPrinter.Location = new System.Drawing.Point(3, 78);
            this.tbSavedPrinter.Name = "tbSavedPrinter";
            this.tbSavedPrinter.ReadOnly = true;
            this.tbSavedPrinter.Size = new System.Drawing.Size(234, 21);
            this.tbSavedPrinter.TabIndex = 1;
            // 
            // bShort
            // 
            this.bShort.Location = new System.Drawing.Point(123, 129);
            this.bShort.Name = "bShort";
            this.bShort.Size = new System.Drawing.Size(114, 20);
            this.bShort.TabIndex = 6;
            this.bShort.Text = "Štampaj";
            this.bShort.Click += new System.EventHandler(this.bShort_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 20);
            this.label2.Text = "Odaberite štampač:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "Trenutno odabrani štampač:";
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(3, 129);
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(114, 21);
            this.tbTest.TabIndex = 11;
            this.tbTest.Text = "KIPS WMS Test";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 20);
            this.label3.Text = "Testiraj štampu:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bShort);
            this.Controls.Add(this.tbSavedPrinter);
            this.Controls.Add(this.cbPrinters);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPrinters;
        private System.Windows.Forms.TextBox tbSavedPrinter;
        private System.Windows.Forms.Button bShort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuItem bSacuvaj;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.Label label3;
    }
}