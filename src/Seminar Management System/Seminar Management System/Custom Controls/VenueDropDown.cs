using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes;

namespace Seminar_Management_System.Custom_Controls
{
    public partial class VenueDropDown : UserControl
    {
        public VenueDropDown()
        {
            InitializeComponent();
        }

        public Venue SelectedVenue { get { return (Venue)cbVenues.SelectedItem; } }

        private void VenueDropDown_Load(object sender, EventArgs e)
        {
            cbVenues.DataSource = DataInstance.venues;
            cbVenues.ValueMember = "ID";
            cbVenues.DisplayMember = "Name";
        }
    }
}
