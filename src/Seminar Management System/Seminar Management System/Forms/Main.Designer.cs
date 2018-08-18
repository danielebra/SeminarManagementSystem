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
            this.SuspendLayout();
            // 
            // btnAddSeminar
            // 
            this.btnAddSeminar.Location = new System.Drawing.Point(23, 13);
            this.btnAddSeminar.Name = "btnAddSeminar";
            this.btnAddSeminar.Size = new System.Drawing.Size(122, 23);
            this.btnAddSeminar.TabIndex = 0;
            this.btnAddSeminar.Text = "Launch Add Seminar";
            this.btnAddSeminar.UseVisualStyleBackColor = true;
            this.btnAddSeminar.Click += new System.EventHandler(this.btnAddSeminar_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 377);
            this.Controls.Add(this.btnAddSeminar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddSeminar;
    }
}

