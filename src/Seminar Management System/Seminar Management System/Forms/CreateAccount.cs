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
            // Connect to the Roles
            comboBox1.DataSource = Authentication.Roles;
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
                Label label = new Label();
                TextBox tb = new TextBox();
                label.AutoSize = true;
                label.Text = p.Name;
                // Determine the location based on how many properties we have gone through
                label.Location = new Point(x, counter * (tb.Height + label.Height + 4));
                // Place the textbox after the label
                tb.Location = new Point(2, label.Location.Y + (label.Height));
                tb.Width = pnlSafeArea.Width - 20;

                // Check for ID and Role because we don't want the user to be able to change these values
                // but we do want them to see what they are set to
                if (p.Name == "ID" || p.Name == "Role")
                {
                    tb.Enabled = false;
                    tb.Text = p.Name == "ID" ? DataInstance.users.Count.ToString() : user.Role.Privilege.ToString();
                }

                // Add the control to the interface
                this.pnlSafeArea.Controls.Add(label);
                this.pnlSafeArea.Controls.Add(tb);

                counter++;
            }
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
            // These checks need to be removed
            if (newUser.GetType() == typeof(Speaker))
                DataInstance.speakers.Add((Speaker)newUser);
            else if (newUser.GetType() == typeof(SeminarOrganiser))
                DataInstance.organisers.Add((SeminarOrganiser)newUser);
            DataInstance.users.Add(newUser);
            this.Close();
        }
    }
}
