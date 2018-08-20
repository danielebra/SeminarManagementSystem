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
        
        public Color BackgroundColor { get { return this.BackColor; } set { this.BackColor = value; } }
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

        public void Resize()
        {
            int scrollbarCompensation = 20;
            this.Width = this.Parent.Size.Width - scrollbarCompensation;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            var foo = this.Parent.Size;
            this.Width = foo.Width;
        }

        private void SeminarItem_Load(object sender, EventArgs e)
        {
            this.Resize();
        }
    }
}
