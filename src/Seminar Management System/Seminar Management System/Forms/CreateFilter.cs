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
        //public System.Linq.Queryable Query { get; set; }
        public List<Seminar> GeneratedSeminarList { get; set; }
        private void btnDone_Click(object sender, EventArgs e)
        {
            // Uses the filter when a user checks the checkbox
            var baseQuery = from s in DataInstance.seminars
                            where (cbRoom.Checked == false || s.Room == roomDropDown1.SelectedRoom)
                            select s;

            var seminars = baseQuery.ToList<Seminar>();
            var f = baseQuery.GetType();
            //Query = baseQuery.AsQueryable();
            this.GeneratedSeminarList = seminars;

            if (FilterUpdated != null)
                FilterUpdated(this, new EventArgs());
        }
    }
}
