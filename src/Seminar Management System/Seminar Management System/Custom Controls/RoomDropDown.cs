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
    // This is used to display all Rooms
    public partial class RoomDropDown : UserControl
    {
        public RoomDropDown()
        {
            InitializeComponent();
        }

        // Expose the currently selected Room
        public Room SelectedRoom { get { return (Room)cbRooms.SelectedItem; } }

        public void setRoom(Room room)
        {
            cbRooms.SelectedIndex = DataInstance.rooms.IndexOf(room);
        }

        private void RoomDropDown_Load(object sender, EventArgs e)
        {
            // Load all the rooms
            cbRooms.DataSource = DataInstance.rooms;
            cbRooms.ValueMember = "ID";
            cbRooms.DisplayMember = "Name";
        }
    }
}
