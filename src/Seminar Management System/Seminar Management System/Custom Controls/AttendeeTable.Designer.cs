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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).BeginInit();
            this.gbAttendeeList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAttendees
            // 
            this.dgvAttendees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAttendees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendees.Location = new System.Drawing.Point(4, 19);
            this.dgvAttendees.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAttendees.MultiSelect = false;
            this.dgvAttendees.Name = "dgvAttendees";
            this.dgvAttendees.Size = new System.Drawing.Size(779, 287);
            this.dgvAttendees.TabIndex = 0;
            this.dgvAttendees.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAttendees_UserDeletingRow);
            // 
            // gbAttendeeList
            // 
            this.gbAttendeeList.Controls.Add(this.dgvAttendees);
            this.gbAttendeeList.Controls.Add(this.panel1);
            this.gbAttendeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAttendeeList.Location = new System.Drawing.Point(0, 0);
            this.gbAttendeeList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAttendeeList.Name = "gbAttendeeList";
            this.gbAttendeeList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAttendeeList.Size = new System.Drawing.Size(787, 335);
            this.gbAttendeeList.TabIndex = 1;
            this.gbAttendeeList.TabStop = false;
            this.gbAttendeeList.Text = "Attendee List";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 306);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 25);
            this.panel1.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(687, 4);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 13, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 17);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total: ";
            // 
            // AttendeeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAttendeeList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AttendeeTable";
            this.Size = new System.Drawing.Size(787, 335);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendees)).EndInit();
            this.gbAttendeeList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAttendees;
        private System.Windows.Forms.GroupBox gbAttendeeList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
    }
}
