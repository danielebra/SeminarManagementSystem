namespace Seminar_Management_System.Forms
{
    partial class CreateFilter
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
            this.roomDropDown1 = new Seminar_Management_System.Custom_Controls.RoomDropDown();
            this.btnDone = new System.Windows.Forms.Button();
            this.cbRoom = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // roomDropDown1
            // 
            this.roomDropDown1.Location = new System.Drawing.Point(12, 12);
            this.roomDropDown1.Name = "roomDropDown1";
            this.roomDropDown1.Size = new System.Drawing.Size(190, 30);
            this.roomDropDown1.TabIndex = 0;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(229, 312);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Filter";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // cbRoom
            // 
            this.cbRoom.AutoSize = true;
            this.cbRoom.Location = new System.Drawing.Point(208, 12);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(93, 17);
            this.cbRoom.TabIndex = 2;
            this.cbRoom.Text = "Filter by Room";
            this.cbRoom.UseVisualStyleBackColor = true;
            // 
            // CreateFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 349);
            this.Controls.Add(this.cbRoom);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.roomDropDown1);
            this.Name = "CreateFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateFilter";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_Controls.RoomDropDown roomDropDown1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckBox cbRoom;
    }
}