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

namespace Seminar_Management_System.Custom_Controls
{
    public partial class SpeakerDetail : UserControl
    {
        public SpeakerDetail()
        {
            InitializeComponent();
        }

        public void Populate(Speaker speaker)
        {
            lblName.Text = "Name: " + speaker.Name;
            lblEmail.Text = "Email: " + speaker.Email;
            lblBiography.Text = speaker.Biography;
        }
    }
}
