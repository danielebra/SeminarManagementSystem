namespace Seminar_Management_System.Custom_Controls
{
    partial class RoomDropDown
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
            this.cbRooms = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbRooms
            // 
            this.cbRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRooms.FormattingEnabled = true;
            this.cbRooms.Location = new System.Drawing.Point(66, 3);
            this.cbRooms.Name = "cbRooms";
            this.cbRooms.Size = new System.Drawing.Size(121, 21);
            this.cbRooms.TabIndex = 12;
            this.cbRooms.SelectedIndexChanged += new System.EventHandler(this.cbRooms_SelectedIndexChanged);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(22, 6);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(35, 13);
            this.lblRoom.TabIndex = 11;
            this.lblRoom.Text = "Room";
            // 
            // RoomDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbRooms);
            this.Controls.Add(this.lblRoom);
            this.Name = "RoomDropDown";
            this.Size = new System.Drawing.Size(190, 30);
            this.Load += new System.EventHandler(this.RoomDropDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRooms;
        private System.Windows.Forms.Label lblRoom;
    }
}
