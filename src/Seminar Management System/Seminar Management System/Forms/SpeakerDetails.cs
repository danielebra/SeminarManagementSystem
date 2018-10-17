using Seminar_Management_System.Classes;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Custom_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System.Forms
{
    public partial class SpeakerDetails : Form
    {
        public SpeakerDetails()
        {
            InitializeComponent();
        }
        private Seminar seminarReference;
        public SpeakerDetails(ref Seminar seminarReference)
        {
            InitializeComponent();
            this.seminarReference = seminarReference;
            createTabs();

        }
        private void createTabs()
        {

            foreach (Speaker speaker in seminarReference.Speakers)
            {
                try
                {
                    TabPage tp = new TabPage();
                    tp.Text = speaker.Name;
                    SpeakerDetail sd = new SpeakerDetail();
                    sd.Populate(speaker);
                    tp.Controls.Add(sd);
                    tcSpeakers.TabPages.Add(tp);
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void SpeakerDetails_Load(object sender, EventArgs e)
        {
            this.Text = "Speaker Details for " + this.seminarReference.Title;
        }
    }
}
