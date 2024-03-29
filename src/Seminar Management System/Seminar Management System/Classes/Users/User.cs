﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_Management_System.Classes.Users
{ 
    // Serializable is used so we can re-produce the contents of a class
    // when creating a deep copy of the object
    [Serializable()]
    abstract public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public int PrivilegeLevel { get; set; }
        public Role Role { get; set; }
        public User()
        {

        }
        public User (int id, string name, string email, string phoneNumber)
        {
            this.ID = id;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
        
    }
}
