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
    public partial class RoomDropDown : UserControl
    {
        public RoomDropDown()
        {
            InitializeComponent();
        }

        public Room SelectedRoom { get { return (Room)cbRooms.SelectedItem; } }

        public void setRoom(Room room)
        {
            cbRooms.SelectedIndex = DataInstance.rooms.IndexOf(room);
        }

        private void RoomDropDown_Load(object sender, EventArgs e)
        {
            cbRooms.DataSource = DataInstance.rooms;
            cbRooms.ValueMember = "ID";
            cbRooms.DisplayMember = "Name";
        }
    }
}
