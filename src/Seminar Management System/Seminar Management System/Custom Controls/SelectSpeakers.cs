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
using Seminar_Management_System.Classes;

namespace Seminar_Management_System.Custom_Controls
{
    // This is used to display all the speakers
        // Allows the user to select multiple speakers
    public partial class SelectSpeakers : UserControl
    {
        public SelectSpeakers()
        {
            InitializeComponent();
        }
        // Expose the currently selected speakers
        public List<Speaker> SelectedSpeakers
        {
            get
            {
                List<Speaker> selectedSpeakers = new List<Speaker>();
                foreach (int i in clbSpeakers.CheckedIndices)
                {
                    selectedSpeakers.Add(Utils.GetAllSpeakers()[i]);
                }
                return selectedSpeakers;
            }
        }

        // Load a list of selected speakers and have it reflect in the interface
        public void setSpeakers(List<Speaker> speakers)
        {
            int index = 0;
            foreach (Speaker speaker in buildSpeakerListFromCheckedListBox(clbSpeakers.Items))
            {
                clbSpeakers.SetItemChecked(index, false);
                // Check if the current speaker is in the list provided by the user 
                if (speakers.Contains(speaker))
                {
                    // Mark the speaker as checked
                    clbSpeakers.SetItemChecked(index, true);
                }
                index++;
            }
        }

        public void setText(string text)
        {
            this.lblInfo.Text = text;
        }
        private List<Speaker> buildSpeakerListFromCheckedListBox(CheckedListBox.ObjectCollection collection)
        {
            // Creates a safe list of existing speakers
            // Assumes the speakers in the list box actually exist in the data base
            List<Speaker> speakerList = new List<Speaker>();
            foreach (string name in collection)
            {
                speakerList.Add(Utils.GetAllSpeakers().Find(speaker => speaker.Name == name));
            }
            return speakerList;
        }
        private void SelectSpeakers_Load(object sender, EventArgs e)
        {
            // Load all the Speakers and set them to unchecked
            foreach (Speaker speaker in Utils.GetAllSpeakers())
            {
                clbSpeakers.Items.Add(speaker.Name, false);
            }
        }
    }
}
