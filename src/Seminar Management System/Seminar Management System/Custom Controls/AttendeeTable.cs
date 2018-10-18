using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Classes;

namespace Seminar_Management_System.Custom_Controls
{
    // This UserControl is used to display a real-time updating attendee list
    // that is connected to a Seminar

    // It supports editing, deleting and viewing
    public partial class AttendeeTable : UserControl
    {
        public AttendeeTable()
        {
            InitializeComponent();
        }
        public void Editable(bool canEdit)
        {
            // Disable editing
            dgvAttendees.ReadOnly = !canEdit;
            // Disable deleting
            dgvAttendees.AllowUserToDeleteRows = canEdit;
            // Dim out the text to be consistent with other control that are disabled
            gbAttendeeList.ForeColor = !canEdit ? SystemColors.ControlDark : SystemColors.ControlText;
        }
        private Seminar seminar; // This is a reference object to an existing seminar
        public void Setup(ref Seminar seminar)
        {
            // Connect the appropriate objects
            this.seminar = seminar;
            dgvAttendees.DataSource = seminar.Attendees;
            dgvAttendees.RowsAdded += DgvAttendees_RowsAdded;
            dgvAttendees.RowsRemoved += DgvAttendees_RowsRemoved;
            updateStatusLabels();
            hideRoleColumn();
            refresh();
        }
        private void hideRoleColumn()
        {
            // Hide the Role column if it exists
            foreach (DataGridViewTextBoxColumn col in dgvAttendees.Columns)
            {
                if (col.Name == "Role")
                {
                    col.Visible = false;
                    break;
                }
            }
        }
        private void DgvAttendees_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateStatusLabels();
        }

        private void DgvAttendees_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateStatusLabels();
        }

        private void updateStatusLabels()
        {
            lblTotal.Text = "Total: " + this.seminar.Attendees.Count;
        }
        // Force a visual refresh request
        public void refresh()
        {
            // dgvAttendees.DataSource = seminar.Attendees;
            this.BindingContext[dgvAttendees.DataSource].EndCurrentEdit();
            dgvAttendees.Refresh();
            dgvAttendees.Parent.Refresh();
        }

        private void dgvAttendees_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Ask the user for confirmation before deleting a row
            if (MessageBox.Show(string.Format("Should {0} be removed from the Attendee List?", e.Row.Cells["Name"].Value), 
                "Delete Attendee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
