namespace Seminar_Management_System.Custom_Controls
{
    partial class SelectSpeakers
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
            this.clbSpeakers = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbSpeakers
            // 
            this.clbSpeakers.FormattingEnabled = true;
            this.clbSpeakers.Location = new System.Drawing.Point(10, 36);
            this.clbSpeakers.Name = "clbSpeakers";
            this.clbSpeakers.Size = new System.Drawing.Size(186, 94);
            this.clbSpeakers.TabIndex = 0;
            this.clbSpeakers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbSpeakers_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.clbSpeakers);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speakers";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInfo.Location = new System.Drawing.Point(7, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(174, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Select the speakers for this seminar";
            // 
            // SelectSpeakers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectSpeakers";
            this.Size = new System.Drawing.Size(214, 147);
            this.Load += new System.EventHandler(this.SelectSpeakers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbSpeakers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfo;
    }
}
