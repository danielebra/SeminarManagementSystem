using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Seminar_Management_System.Classes;
using Seminar_Management_System.Classes.Users;

namespace Seminar_Management_System.Forms
{
    // This form is used to create a new User Account
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        private User interfaceMadeFor;
        private void CreateAccount_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Utils.AllRolesWithoutAttendee();
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the screen
            pnlSafeArea.Controls.Clear();

            // Determine which interface to build based on the chosen Role
            switch  (((Role)(comboBox1.SelectedValue)).Name)
            {
                case Role.Names.Attendee:
                    buildBaseInterface(new SeminarAttendee());
                    break;
                case Role.Names.Speaker:
                    buildBaseInterface(new Speaker());

                    break;
                case Role.Names.Host:
                    buildBaseInterface(new SeminarHost());

                    break;
                case Role.Names.Organiser:
                    buildBaseInterface(new SeminarOrganiser());

                    break;
                case Role.Names.Admin:
                    buildBaseInterface(new SystemAdmin());
                    break;
                default:
                    break;
            }
        }
        private void buildBaseInterface(User user)
        {
            // Build an interface from the properties found in the polymorphic object of User
            this.interfaceMadeFor = user;
            int counter = 0;
            int x = 5; // x pixel location
            foreach (PropertyInfo p in user.GetType().GetProperties())
            {
                pnlSafeArea.Controls.Add(createLabel(p));
                pnlSafeArea.Controls.Add(createTextBox(p, user));
            }
        }

        private Label createLabel(PropertyInfo p)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = p.Name;
            if (pnlSafeArea.Controls.Count > 0)
            {
                var lastControl = pnlSafeArea.Controls[pnlSafeArea.Controls.Count - 1];
                var loc = lastControl.Location;
                loc.Y += lastControl.Height + 4;//label.Height + 4;
                label.Location = loc;
            }
            else
            {
                label.Location = new Point(5, 4);
            }
            return label;
        }

        private TextBox createTextBox(PropertyInfo p, User u)
        {
            TextBox tb = new TextBox();

            if (pnlSafeArea.Controls.Count > 0)
            {
                var lastControl = pnlSafeArea.Controls[pnlSafeArea.Controls.Count - 1];
                var loc = lastControl.Location;

                loc.Y += lastControl.Height + 4;
                tb.Location = loc;
            }
            else
                tb.Location = new Point(2, 15);
            tb.Width = pnlSafeArea.Width - 20;
            if (p.Name == "Biography")
            {
                tb.Multiline = true;
                tb.ScrollBars = ScrollBars.Both;
                tb.Height = 200;
            }
            if (p.Name == "ID" || p.Name == "Role")
            {
                tb.Enabled = false;
                tb.Text = p.Name == "ID" ? DataInstance.users.Count.ToString() : u.Role.Privilege.ToString();
            }
            return tb;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            pnlSafeArea.Controls.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Collect data from all input fields
            IEnumerable<Control> tbs = Utils.GetControlsFromControl(pnlSafeArea, typeof(TextBox));
            List<string> vals = new List<string>();
            foreach (var control in tbs)
                vals.Add(((TextBox)control).Text);

            var newUser = interfaceMadeFor;
            PropertyInfo[] props = newUser.GetType().GetProperties();

            // Populate the property values to what was collected
            for (int i = 0; i != props.Length; i++)
            {
                // This will require error validation
                if (props[i].PropertyType == typeof(Role))
                {
                    props[i].SetValue(newUser, Authentication.GetRoleFromPrivilegeLevel(int.Parse(vals[i])));
                }

                else if (props[i].PropertyType == typeof(Int32))
                    props[i].SetValue(newUser, int.Parse(vals[i]), null);
                else
                    props[i].SetValue(newUser, vals[i], null);
            }
            // Add the new User to the list of Users
            DataInstance.users.Add(newUser);
            MessageBox.Show("An account for " + newUser.Name + " has been created. ",
                "New Account Successfully Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
