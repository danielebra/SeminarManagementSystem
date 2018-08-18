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

namespace Seminar_Management_System.Forms
{
    public partial class ViewSeminar : Form
    {
        public ViewSeminar()
        {
            InitializeComponent();
        }
        public ViewSeminar(ref Seminar seminar)
        {
            InitializeComponent();
            seminarReference = seminar;
        }
        private Seminar seminarReference { get; set; }

        private void ViewSeminar_Load(object sender, EventArgs e)
        {
            if (seminarReference != null)
            {
                lblTitle.Text = seminarReference.Title;
                lblDescription.Text = seminarReference.Description;
            }
        }
    }
}
