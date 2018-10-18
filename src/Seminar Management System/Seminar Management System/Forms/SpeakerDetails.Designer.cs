namespace Seminar_Management_System.Forms
{
    partial class SpeakerDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeakerDetails));
            this.tcSpeakers = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tcSpeakers
            // 
            this.tcSpeakers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSpeakers.Location = new System.Drawing.Point(0, 0);
            this.tcSpeakers.Name = "tcSpeakers";
            this.tcSpeakers.SelectedIndex = 0;
            this.tcSpeakers.Size = new System.Drawing.Size(572, 490);
            this.tcSpeakers.TabIndex = 0;
            // 
            // SpeakerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 490);
            this.Controls.Add(this.tcSpeakers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpeakerDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speaker Details for Seminar Title";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SpeakerDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcSpeakers;
    }
}