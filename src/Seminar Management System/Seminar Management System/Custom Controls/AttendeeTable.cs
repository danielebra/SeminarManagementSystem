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
    public partial class AttendeeTable : UserControl
    {
        public AttendeeTable()
        {
            InitializeComponent();
        }
        private Seminar seminar;
        public void Setup(ref Seminar seminar)
        {
            this.seminar = seminar;
            dgvAttendees.DataSource = this.seminar.Attendees;
        }
        public void refresh()
        {
            // dgvAttendees.DataSource = seminar.Attendees;
            this.BindingContext[dgvAttendees.DataSource].EndCurrentEdit();
            dgvAttendees.Refresh();
            dgvAttendees.Parent.Refresh();
        }
    }
}
