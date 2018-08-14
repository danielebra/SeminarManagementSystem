using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnAddSeminar_Click(object sender, EventArgs e)
        {
            AddSeminar addSeminar = new AddSeminar();
            addSeminar.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DataInstance.organisers.Add(new Classes.Users.SeminarOrganiser("Bob"));
            DataInstance.organisers.Add(new Classes.Users.SeminarOrganiser("Tim"));

        }
    }
}
