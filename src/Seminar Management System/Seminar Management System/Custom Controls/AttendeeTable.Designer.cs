namespace Seminar_Management_System.Custom_Controls
{
    partial class AttendeeTable
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
            this.dgvAttendees = new System.Windows.Forms.DataGridView();
            this.gbAttendeeList = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).BeginInit();
            this.gbAttendeeList.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAttendees
            // 
            this.dgvAttendees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAttendees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendees.Location = new System.Drawing.Point(3, 16);
            this.dgvAttendees.Name = "dgvAttendees";
            this.dgvAttendees.Size = new System.Drawing.Size(584, 253);
            this.dgvAttendees.TabIndex = 0;
            this.dgvAttendees.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAttendees_UserDeletingRow);
            // 
            // gbAttendeeList
            // 
            this.gbAttendeeList.Controls.Add(this.dgvAttendees);
            this.gbAttendeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAttendeeList.Location = new System.Drawing.Point(0, 0);
            this.gbAttendeeList.Name = "gbAttendeeList";
            this.gbAttendeeList.Size = new System.Drawing.Size(590, 272);
            this.gbAttendeeList.TabIndex = 1;
            this.gbAttendeeList.TabStop = false;
            this.gbAttendeeList.Text = "Attendee List";
            // 
            // AttendeeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAttendeeList);
            this.Name = "AttendeeTable";
            this.Size = new System.Drawing.Size(590, 272);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).EndInit();
            this.gbAttendeeList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAttendees;
        private System.Windows.Forms.GroupBox gbAttendeeList;
    }
}
