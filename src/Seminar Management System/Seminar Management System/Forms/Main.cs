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
using Seminar_Management_System.Custom_Controls;

namespace Seminar_Management_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnAddSeminar_Click(object sender, EventArgs e)
        {
            AddSeminar addSeminar = new AddSeminar();
            addSeminar.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DataInstance.populateWithMockData();
            for (int i = 0; i != 10; i++)
            {
                btnTest_Click(null, null);
            }
        }
        private List<SeminarItem> seminarItems = new List<SeminarItem>();
        private bool pragmaOnce = true;
        private void btnTest_Click(object sender, EventArgs e)
        {
            SeminarItem foo = new SeminarItem();
            foo.Location = new Point(0, foo.Size.Height * seminarItems.Count);
            seminarItems.Add(foo);
            if (pragmaOnce)
            {
                pragmaOnce = false;
                var bar = DataInstance.seminars.FirstOrDefault();
                foo.Populate(ref bar);
            }
            pnlSeminarView.Controls.Add(foo);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            var foo = DataInstance.seminars.FirstOrDefault();
        }
    }
}
