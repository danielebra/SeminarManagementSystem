using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes;
namespace Seminar_Management_System.Forms
{
    // This is used to login as different users
        // Essentially changing what components are visible to each user
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Set the current logged in user to an Admin
            DataInstance.LoggedInUser = Authentication.GetRoleFromName(Role.Names.Admin);
        }

        private void btnAttendee_Click(object sender, EventArgs e)
        {
            // Set the current logged in user to an Attendee
            DataInstance.LoggedInUser = Authentication.GetRoleFromName(Role.Names.Attendee);
        }
    }
}
