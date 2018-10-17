namespace Seminar_Management_System.Custom_Controls
{
    partial class SpeakerDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblBiography = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(18, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(17, 41);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 20);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email: ";
            // 
            // lblBiography
            // 
            this.lblBiography.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBiography.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiography.Location = new System.Drawing.Point(18, 93);
            this.lblBiography.Name = "lblBiography";
            this.lblBiography.Size = new System.Drawing.Size(362, 181);
            this.lblBiography.TabIndex = 2;
            this.lblBiography.Text = "Biography";
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.Location = new System.Drawing.Point(19, 76);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(54, 13);
            this.lblBio.TabIndex = 3;
            this.lblBio.Text = "Biography";
            // 
            // SpeakerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.lblBiography);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Name = "SpeakerDetail";
            this.Size = new System.Drawing.Size(398, 289);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblBiography;
        private System.Windows.Forms.Label lblBio;
    }
}
