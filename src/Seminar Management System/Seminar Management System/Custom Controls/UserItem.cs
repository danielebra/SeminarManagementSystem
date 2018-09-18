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
using Seminar_Management_System.Forms;

namespace Seminar_Management_System.Custom_Controls
{
    public partial class UserItem : UserControl
    {
        public UserItem()
        {
            InitializeComponent();
        }

        public User UserReference;
        public bool isUsingAlternativeColor = false;
        public Color BackgroundColor { get { return this.BackColor; } set { this.BackColor = value; } }
        public void Populate(ref User user)
        {
            UserReference = user;
            lblName.Text = user.Name;
            lblRole.Text = user.Role.Name;
            CustomBackgroundColor(true);
            
        }
        public void AlternativeColor()
        {
            CustomBackgroundColor(false);
            this.isUsingAlternativeColor = true;
        }
        private void CustomBackgroundColor(bool defaultShade = true)
        {
            switch (UserReference.Role.Name)
            {
                case Role.Names.Admin:
                    this.BackColor = defaultShade ? Color.Orange : Color.DarkOrange;
                    break;
                case Role.Names.Host:
                    this.BackColor = defaultShade ? Color.PaleGreen : Color.LightGreen;
                    break;
                case Role.Names.Organiser:
                    this.BackColor = defaultShade ? Color.MediumPurple : Color.BlueViolet;
                    break;
                default:
                    this.BackColor = defaultShade ? Color.LightCoral : Color.Salmon;
                    break;
            }
        }
        private void UserItem_Load(object sender, EventArgs e)
        {
            this.Resize();
        }

        public void Resize()
        {
            int scrollbarCompensation = 20;
            this.Width = this.Parent.Size.Width - scrollbarCompensation;
        }

        private void btnView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewUser viewUser = new ViewUser(ref UserReference);
            viewUser.Show();
        }
    }
}
