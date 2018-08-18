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
    public partial class SelectSpeakers : UserControl
    {
        public SelectSpeakers()
        {
            InitializeComponent();
        }
        public List<Speaker> SelectedSpeakers
        {
            get
            {
                List<Speaker> selectedSpeakers = new List<Speaker>();
                foreach (int i in clbSpeakers.CheckedIndices)
                {
                    selectedSpeakers.Add(DataInstance.speakers[i]);
                }
                return selectedSpeakers;
            }
        }
        private void SelectSpeakers_Load(object sender, EventArgs e)
        {
            foreach (Speaker speaker in DataInstance.speakers)
            {
                clbSpeakers.Items.Add(speaker.Name, false);
            }
        }
    }
}
