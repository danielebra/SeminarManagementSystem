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
using Seminar_Management_System.Classes;

namespace Seminar_Management_System.Custom_Controls
{
    // This is used to display all the Organisers
    public partial class OrganiserDropDown : UserControl
    {
        public OrganiserDropDown()
        {
            InitializeComponent();
        }

        // Expose the currently selected Organiser
        public SeminarOrganiser SelectedOrganiser { get { return (SeminarOrganiser)cbOrganisers.SelectedItem; } }

        public void setOrganiser(SeminarOrganiser organiser)
        {
            cbOrganisers.SelectedIndex = Utils.GetAllOrganisers().IndexOf(organiser);//DataInstance.organisers.IndexOf(organiser);
        }

        private void OrganiserDropDown_Load(object sender, EventArgs e)
        {
            // Connect to the list of organisers and set it as the DataSource
            cbOrganisers.DataSource = Utils.GetAllOrganisers();//DataInstance.organisers;
            cbOrganisers.ValueMember = "ID";
            cbOrganisers.DisplayMember = "Name";
        }
    }
}
