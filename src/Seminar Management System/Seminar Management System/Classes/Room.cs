using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public Room(int id, string name, string location, int capacity)
        {
            this.ID = id;
            this.Name = name;
            this.Location = location;
            this.Capacity = capacity;
        }
    }
}
