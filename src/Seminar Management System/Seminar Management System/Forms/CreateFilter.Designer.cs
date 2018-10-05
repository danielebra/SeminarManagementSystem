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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateFilter));
            this.roomDropDown1 = new Seminar_Management_System.Custom_Controls.RoomDropDown();
            this.btnDone = new System.Windows.Forms.Button();
            this.cbRoom = new System.Windows.Forms.CheckBox();
            this.selectSpeakers1 = new Seminar_Management_System.Custom_Controls.SelectSpeakers();
            this.organiserDropDown1 = new Seminar_Management_System.Custom_Controls.OrganiserDropDown();
            this.cbOrganiser = new System.Windows.Forms.CheckBox();
            this.cbSpeaker = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.btnDone.BackColor = System.Drawing.Color.LimeGreen;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Location = new System.Drawing.Point(211, 314);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Filter";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // cbRoom
            // 
            this.cbRoom.AutoSize = true;
            this.cbRoom.Location = new System.Drawing.Point(211, 17);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(93, 17);
            this.cbRoom.TabIndex = 2;
            this.cbRoom.Text = "Filter by Room";
            this.cbRoom.UseVisualStyleBackColor = true;
            // 
            // selectSpeakers1
            // 
            this.selectSpeakers1.Location = new System.Drawing.Point(12, 84);
            this.selectSpeakers1.Name = "selectSpeakers1";
            this.selectSpeakers1.Size = new System.Drawing.Size(214, 147);
            this.selectSpeakers1.TabIndex = 3;
            // 
            // organiserDropDown1
            // 
            this.organiserDropDown1.Location = new System.Drawing.Point(12, 48);
            this.organiserDropDown1.Name = "organiserDropDown1";
            this.organiserDropDown1.Size = new System.Drawing.Size(190, 30);
            this.organiserDropDown1.TabIndex = 4;
            // 
            // cbOrganiser
            // 
            this.cbOrganiser.AutoSize = true;
            this.cbOrganiser.Location = new System.Drawing.Point(211, 57);
            this.cbOrganiser.Name = "cbOrganiser";
            this.cbOrganiser.Size = new System.Drawing.Size(110, 17);
            this.cbOrganiser.TabIndex = 5;
            this.cbOrganiser.Text = "Filter by Organiser";
            this.cbOrganiser.UseVisualStyleBackColor = true;
            // 
            // cbSpeaker
            // 
            this.cbSpeaker.AutoSize = true;
            this.cbSpeaker.Location = new System.Drawing.Point(241, 148);
            this.cbSpeaker.Name = "cbSpeaker";
            this.cbSpeaker.Size = new System.Drawing.Size(105, 17);
            this.cbSpeaker.TabIndex = 6;
            this.cbSpeaker.Text = "Filter by Speaker";
            this.cbSpeaker.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(292, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CreateFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 349);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbSpeaker);
            this.Controls.Add(this.cbOrganiser);
            this.Controls.Add(this.organiserDropDown1);
            this.Controls.Add(this.selectSpeakers1);
            this.Controls.Add(this.cbRoom);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.roomDropDown1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Seminars";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateFilter_FormClosing);
            this.Load += new System.EventHandler(this.CreateFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_Controls.RoomDropDown roomDropDown1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckBox cbRoom;
        private Custom_Controls.SelectSpeakers selectSpeakers1;
        private Custom_Controls.OrganiserDropDown organiserDropDown1;
        private System.Windows.Forms.CheckBox cbOrganiser;
        private System.Windows.Forms.CheckBox cbSpeaker;
        private System.Windows.Forms.Button btnCancel;
    }
}