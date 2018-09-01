using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Classes;
using System.Reflection;
namespace Seminar_Management_System.Forms
{
    public partial class RegisterAttendee : Form
    {
        public RegisterAttendee()
        {
            InitializeComponent();
        }
        public RegisterAttendee(ref Seminar seminar)
        {
            InitializeComponent();
            seminarReference = seminar;
        }
        private Seminar seminarReference { get; set; }
        public event EventHandler AttendeeRegistered;

        private void RegisterAttendee_Load(object sender, EventArgs e)
        {
            CreateInterface();
        }

        public void CreateInterface()
        {
            int counter = 0;
            int x = 5;
            foreach (PropertyInfo p in typeof(SeminarAttendee).GetProperties())
            {
                if (p.Name == "ID")
                    continue;
                Label label = new Label();
                TextBox tb = new TextBox();
                label.AutoSize = true;
                label.Text = p.Name;
                label.Location = new Point(x, counter * (tb.Height + label.Height + 4));
                
                tb.Location = new Point(2, label.Location.Y + (label.Height));

                this.Controls.Add(label);
                this.Controls.Add(tb);

                counter++;

            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IEnumerable<Control> tbs = Utils.GetControlsFromControl(this, typeof(TextBox));
            List<string> vals = new List<string>();
            foreach (var cont in tbs)
                vals.Add(((TextBox)cont).Text);
            seminarReference.Attendees.Add(new SeminarAttendee(seminarReference.Attendees.Count,vals[0], vals[1], vals[2]));
            if (this.AttendeeRegistered != null)
            {
                this.AttendeeRegistered(this, new EventArgs());
            }
            this.Close();

        }
    }
}
