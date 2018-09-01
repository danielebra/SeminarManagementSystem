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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            FieldInfo[] fields = typeof(Privilege).GetFields(BindingFlags.Static | BindingFlags.Public);
            comboBox1.DataSource = fields;
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlSafeArea.Controls.Clear();

            switch ((int)((FieldInfo)comboBox1.SelectedValue).GetValue(null))
            {
                case Privilege.Attendee:
                    buildBaseInterface(new SeminarAttendee());
                    break;
                case Privilege.Speaker:
                    buildBaseInterface(new Speaker());

                    break;
                case Privilege.Host:
                    buildBaseInterface(new SeminarHost());

                    break;
                case Privilege.Organiser:
                    buildBaseInterface(new SeminarOrganiser());

                    break;
                case Privilege.Admin:
                    buildBaseInterface(new SystemAdmin());

                    break;
                default:
                    break;
            }
        }
        private void buildBaseInterface(User user)
        {
            int counter = 0;
            int x = 5;
            foreach (PropertyInfo p in user.GetType().GetProperties())
            {
                Label label = new Label();
                TextBox tb = new TextBox();
                label.AutoSize = true;
                label.Text = p.Name;
                label.Location = new Point(x, counter * (tb.Height + label.Height + 4));

                tb.Location = new Point(2, label.Location.Y + (label.Height));

                this.pnlSafeArea.Controls.Add(label);
                this.pnlSafeArea.Controls.Add(tb);

                counter++;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            pnlSafeArea.Controls.Clear();
        }
    }
}
