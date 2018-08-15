namespace Seminar_Management_System.Custom_Controls
{
    partial class OrganiserDropDown
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
            this.cbOrganisers = new System.Windows.Forms.ComboBox();
            this.lblOrganiser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbOrganisers
            // 
            this.cbOrganisers.FormattingEnabled = true;
            this.cbOrganisers.Location = new System.Drawing.Point(66, 6);
            this.cbOrganisers.Name = "cbOrganisers";
            this.cbOrganisers.Size = new System.Drawing.Size(121, 21);
            this.cbOrganisers.TabIndex = 10;
            // 
            // lblOrganiser
            // 
            this.lblOrganiser.AutoSize = true;
            this.lblOrganiser.Location = new System.Drawing.Point(8, 9);
            this.lblOrganiser.Name = "lblOrganiser";
            this.lblOrganiser.Size = new System.Drawing.Size(52, 13);
            this.lblOrganiser.TabIndex = 9;
            this.lblOrganiser.Text = "Organiser";
            // 
            // OrganiserDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbOrganisers);
            this.Controls.Add(this.lblOrganiser);
            this.Name = "OrganiserDropDown";
            this.Size = new System.Drawing.Size(190, 30);
            this.Load += new System.EventHandler(this.OrganiserDropDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOrganisers;
        private System.Windows.Forms.Label lblOrganiser;
    }
}
