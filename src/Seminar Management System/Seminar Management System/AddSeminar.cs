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
using Seminar_Management_System.Classes.Seminar;

namespace Seminar_Management_System
{
    public partial class AddSeminar : Form
    {
        public AddSeminar()
        {
            InitializeComponent();
        }
        

        private void AddSeminar_Load(object sender, EventArgs e)
        {
            foreach (SeminarOrganiser organiser in DataInstance.organisers)
                cbOrganizers.Items.Add(organiser.Name);
            cbOrganizers.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: populate other seminar data
            Seminar seminar = new Seminar();
            // Grab organiser object based on selected item in combo box
            SeminarOrganiser organiser = DataInstance.organisers.Where(o => o.Name.Equals(cbOrganizers.SelectedValue)).FirstOrDefault();
            seminar.Organiser = organiser;
        }
    }
}
