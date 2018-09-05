using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seminar_Management_System.Classes;
using System.Linq.Expressions;

namespace Seminar_Management_System.Forms
{
    public partial class CreateFilter : Form
    {
        public CreateFilter()
        {
            InitializeComponent();
        }
        public event EventHandler FilterUpdated;

        private void btnDone_Click(object sender, EventArgs e)
        {
            // Uses the filter when a user checks the checkbox
            PortableFilter.ByRoom = cbRoom.Checked;
            PortableFilter.Room = cbRoom.Checked ? roomDropDown1.SelectedRoom : null;

            if (FilterUpdated != null)
                FilterUpdated(this, new EventArgs());
            this.Close();
        }
    }

    // This will be moved to its own file in the future
    public static class PortableFilter
    {
        public static bool ByRoom { get; set; }
        public static Room Room { get; set; }

        public static List<Seminar> Execute()
        {
            var query = from s in DataInstance.seminars
                        where (ByRoom == false || s.Room == Room)
                        select s;
            return query.ToList<Seminar>();
        }
    }
}
