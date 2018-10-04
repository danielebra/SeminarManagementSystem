using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Seminar_Management_System.Classes;
using Seminar_Management_System.Classes.Users;

namespace Seminar_Management_System.Custom_Controls
{
    // This is used to display all Roles
    public partial class RoleDropDown : UserControl
    {
        public RoleDropDown()
        {
            InitializeComponent();
        }
        // Expose the currently selected Role
        public Role SelectedRole { get { return (Role)cbRole.SelectedItem; } }
        public event EventHandler SelectedRoleChanged;
        public void LoadFromUser(User user)
        {
            // TODO
            // Should user no longer have a privilege level and have a role instead?
            cbRole.SelectedItem = user.Role;
            cbRole_SelectedValueChanged(null, null);
        }
        private void RoleDropDown_Load(object sender, EventArgs e)
        {
            // Load all the Roles that exist
            cbRole.DataSource = Utils.AllRolesWithoutAttendee();//Authentication.Roles;
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "Privilege";
        }

        private void cbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SelectedRoleChanged != null)
                SelectedRoleChanged(this, null);
        }
    }
}
