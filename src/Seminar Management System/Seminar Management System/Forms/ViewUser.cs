using Seminar_Management_System.Classes.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System.Forms
{
    public partial class ViewUser : Form
    {
        public ViewUser()
        {
            InitializeComponent();
        }
        public ViewUser(ref User user)
        {
            InitializeComponent();
            userReference = user;
        }
        private User userReference { get; set; }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            populateDataFields();
        }
        private void populateDataFields()
        {
            if (userReference != null)
            {
                tbName.Text = userReference.Name;
            }
        }
    }
}
