﻿using Seminar_Management_System.Classes.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System.Classes
{
    // This class is used for project wide re-usable functions
    class Utils
    {
        // Returns all the Controls that match a certain type
        // I.e.: All the text boxes from a form
        static public IEnumerable<Control> GetControlsFromControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetControlsFromControl(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        // This is used to create a deep copy of an object
        // It is used throughout the project to duplicate objects that are memory references
        internal static class ObjectCloner
        {
            // Serialize and deserialize objects
            public static object Clone(object obj)
            {
                using (MemoryStream buffer = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(buffer, obj);
                    buffer.Position = 0;
                    object temp = formatter.Deserialize(buffer);
                    return temp;
                }
            }
        }
        public static List<Role> AllRolesWithoutAttendee()
        {
            var stripAttendee = Authentication.Roles;
            foreach (var x in stripAttendee)
            {
                if (x.Name == Role.Names.Attendee)
                {
                    stripAttendee.Remove(x);
                    break;
                }
            }
            return stripAttendee;
        }

        public static List<Speaker> GetAllSpeakers()
        {
            return DataInstance.users.Where(u => u.GetType() == typeof(Speaker)).Cast<Speaker>().ToList();
        }

        public static List<SeminarOrganiser> GetAllOrganisers()
        {
            return DataInstance.users.Where(u => u.GetType() == typeof(SeminarOrganiser)).Cast<SeminarOrganiser>().ToList();
        }

        public static Speaker GetSpeakerById(int id)
        {
            return (Speaker)DataInstance.users.Where(u => u.ID == id).FirstOrDefault();
        }

    }
}
