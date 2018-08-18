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
    public partial class SeminarItem : UserControl
    {
        public SeminarItem()
        {
            InitializeComponent();
        }
        public Seminar SeminarReference;
        public void Populate(Seminar seminar)
        {
            SeminarReference = seminar;
            lblTitle.Text = seminar.Title;
            lblDescription.Text = seminar.Description;
        }
    }
}
