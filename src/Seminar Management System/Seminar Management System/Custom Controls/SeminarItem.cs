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
using Seminar_Management_System.Forms;
namespace Seminar_Management_System.Custom_Controls
{
    public partial class SeminarItem : UserControl
    {
        public SeminarItem()
        {
            InitializeComponent();
        }
        public Seminar SeminarReference;
        // the seminar param might become a ref in the future
        public void Populate(ref Seminar seminar)
        {
            SeminarReference = seminar;
            lblTitle.Text = seminar.Title;
            lblDescription.Text = seminar.Description;
        }

        private void btnView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSeminar viewSeminar = new ViewSeminar(ref SeminarReference);
            viewSeminar.Show();
        }
    }
}
