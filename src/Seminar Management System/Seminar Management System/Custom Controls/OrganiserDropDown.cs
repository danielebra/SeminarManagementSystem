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
    public partial class OrganiserDropDown : UserControl
    {
        public OrganiserDropDown()
        {
            InitializeComponent();
        }

        public SeminarOrganiser SelectedOrganiser { get { return (SeminarOrganiser)cbOrganisers.SelectedItem; } }

        private void OrganiserDropDown_Load(object sender, EventArgs e)
        {
            cbOrganisers.DataSource = DataInstance.organisers;
            cbOrganisers.ValueMember = "ID";
            cbOrganisers.DisplayMember = "Name";
        }
    }
}
