using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes
{
    // A Room is a physical room that is used for having a Seminar in
    public class Room
    {
        public int ID { get; set; } // Unique identifier
        public string Name { get; set; } // Friendly Name
        public string Location { get; set; } // Location eg: CB11.04.100
        public int Capacity { get; set; } // How many people can fit in this room

        public Room(int id, string name, string location, int capacity)
        {
            this.ID = id;
            this.Name = name;
            this.Location = location;
            this.Capacity = capacity;
        }
    }
}
