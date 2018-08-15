namespace Seminar_Management_System.Custom_Controls
{
    partial class VenueDropDown
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
            this.cbVenues = new System.Windows.Forms.ComboBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbVenues
            // 
            this.cbVenues.FormattingEnabled = true;
            this.cbVenues.Location = new System.Drawing.Point(66, 3);
            this.cbVenues.Name = "cbVenues";
            this.cbVenues.Size = new System.Drawing.Size(121, 21);
            this.cbVenues.TabIndex = 12;
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Location = new System.Drawing.Point(22, 6);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(38, 13);
            this.lblVenue.TabIndex = 11;
            this.lblVenue.Text = "Venue";
            // 
            // VenueDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbVenues);
            this.Controls.Add(this.lblVenue);
            this.Name = "VenueDropDown";
            this.Size = new System.Drawing.Size(190, 30);
            this.Load += new System.EventHandler(this.VenueDropDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbVenues;
        private System.Windows.Forms.Label lblVenue;
    }
}
