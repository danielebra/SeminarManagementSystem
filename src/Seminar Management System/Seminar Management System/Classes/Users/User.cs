using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{ 
    abstract public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public User (int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        
    }
}
