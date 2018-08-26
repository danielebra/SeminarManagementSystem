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
        public void Setup(ref Seminar seminar)
        {
            dgvAttendees.DataSource = seminar.Attendees;
        }
        private void AttendeeTable_Load(object sender, EventArgs e)
        {
            //dgvAttendees.DataSource = DataInstance.seminars;
        }
    }
}
