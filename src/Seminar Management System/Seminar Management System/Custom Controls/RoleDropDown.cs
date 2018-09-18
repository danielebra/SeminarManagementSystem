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
    public partial class RoleDropDown : UserControl
    {
        public RoleDropDown()
        {
            InitializeComponent();
        }
        
        public Role SelectedRole { get { return (Role)cbRole.SelectedItem; } }
        public void LoadFromUser(User user)
        {
            // TODO
            // Should user no longer have a privilege level and have a role instead?
            cbRole.SelectedItem = user.Role;
        }
        private void RoleDropDown_Load(object sender, EventArgs e)
        {
            cbRole.DataSource = Authentication.Roles;
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "Privilege";
        }
    }
}
