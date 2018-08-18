namespace Seminar_Management_System
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAddSeminar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.pnlSeminarView = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.pnlSeminarView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddSeminar
            // 
            this.btnAddSeminar.Location = new System.Drawing.Point(797, 470);
            this.btnAddSeminar.Name = "btnAddSeminar";
            this.btnAddSeminar.Size = new System.Drawing.Size(122, 23);
            this.btnAddSeminar.TabIndex = 0;
            this.btnAddSeminar.Text = "Launch Add Seminar";
            this.btnAddSeminar.UseVisualStyleBackColor = true;
            this.btnAddSeminar.Click += new System.EventHandler(this.btnAddSeminar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(931, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Location = new System.Drawing.Point(0, 521);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(931, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // pnlSeminarView
            // 
            this.pnlSeminarView.AutoScroll = true;
            this.pnlSeminarView.Controls.Add(this.btnAddSeminar);
            this.pnlSeminarView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeminarView.Location = new System.Drawing.Point(0, 25);
            this.pnlSeminarView.Name = "pnlSeminarView";
            this.pnlSeminarView.Size = new System.Drawing.Size(931, 496);
            this.pnlSeminarView.TabIndex = 3;
            // 
            // btnTest
            // 
            this.btnTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(79, 22);
            this.btnTest.Text = "Add Seminar";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 546);
            this.Controls.Add(this.pnlSeminarView);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlSeminarView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddSeminar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel pnlSeminarView;
        private System.Windows.Forms.ToolStripButton btnTest;
    }
}

