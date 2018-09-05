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

        public Color BackgroundColor { get { return this.BackColor; } set { this.BackColor = value; } }
        public void Populate(ref User user)
        {
            UserReference = user;
            lblName.Text = user.Name;
            lblRole.Text = user.PrivilegeLevel.ToString();
            switch (user.PrivilegeLevel)
            {
                case Privilege.Admin:
                    this.BackColor = Color.Orange;
                    break;
                case Privilege.Host:
                    this.BackColor = Color.PaleGreen;
                    break;
                case Privilege.Organiser:
                    this.BackColor = Color.MediumPurple;
                    break;
                default:
                    this.BackColor = Color.LightCoral;
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
