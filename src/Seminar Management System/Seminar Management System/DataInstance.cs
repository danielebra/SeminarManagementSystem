using System;
using System.Collections.Generic;
using System.Data;
using Seminar_Management_System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar_Management_System.Classes.Users;
using Seminar_Management_System.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Seminar_Management_System
{
    static class DataInstance
    {


        public static List<SeminarOrganiser> organisers = new List<SeminarOrganiser>();
        public static List<Room> rooms = new List<Room>();
        public static List<Speaker> speakers = new List<Speaker>();
        public static ObservableCollection<Seminar> seminars = new ObservableCollection<Seminar>();
        public static string _connectionString; 

        public static void populateWithData()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //instantiate and open new connection using DB Connection string
                conn.ConnectionString = _connectionString;
                conn.Open();

                //Create commands
                SqlCommand cmdGetOrganisers = new SqlCommand("SELECT * FROM Person p WHERE p.IsOrganiser = 1", conn);
                SqlCommand cmdGetRooms = new SqlCommand("SELECT * FROM Venue", conn);
                SqlCommand cmdGetSpeakers = new SqlCommand("SELECT * FROM Person p WHERE p.IsSpeaker = 1", conn);
                SqlCommand cmdGetAttendees = new SqlCommand("SELECT * FROM Person p WHERE p.IsAttendee = 1", conn);
                SqlCommand cmdGetSeminars = new SqlCommand("SELECT * FROM Seminar", conn);


                //Populate Organiser List
                using (SqlDataReader reader = cmdGetOrganisers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        organisers.Add(new SeminarOrganiser((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString()));
                    }
                }

                //Populate Rooms List
                using (SqlDataReader reader = cmdGetRooms.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room((int)reader["ID"], reader["Name"].ToString(), reader["Location"].ToString(), (int)reader["Capacity"]));
                    }
                }

                //Populate Speakers List
                using (SqlDataReader reader = cmdGetSpeakers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        speakers.Add(new Speaker((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString(), reader["Biography"].ToString()));
                    }
                }

                //Populate Attendees List
                BindingList<SeminarAttendee> attendeeList = new BindingList<SeminarAttendee>();
                using (SqlDataReader reader = cmdGetAttendees.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attendeeList.Add(new SeminarAttendee((int)reader["ID"], reader["Name"].ToString(), reader["Email"].ToString(), reader["PhoneNumber"].ToString()));
                    }
                }

                //Populate Seminars List
                using (SqlDataReader reader = cmdGetSeminars.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var organiser = organisers.Where(o => o.ID == (int)reader["OrganiserPersonID"]).ToList();
                        var room = rooms.Where(r => r.ID == (int)reader["VenueID"]).ToList();

                        seminars.Add(new Seminar(organiser[0], room[0], speakers, attendeeList, reader["Label"].ToString(), reader["Description"].ToString(), DateTime.Now, DateTime.Today));
                    }
                }


            }
        }

        public static void populateWithMockData()
        {
            DataInstance.organisers.Add(new SeminarOrganiser(0, "Bob", "bob@staff.com", "111"));
            DataInstance.organisers.Add(new SeminarOrganiser(1, "Tim", "tim@staff.com", "222"));

            DataInstance.rooms.Add(new Room(0, "Building 11", "Ultimo", 100));
            DataInstance.rooms.Add(new Room(1, "Building 10", "Ultimo", 200));

            DataInstance.speakers.Add(new Speaker(0, "Dr James", "james@speakers.com", String.Empty, "This is a biography..."));
            DataInstance.speakers.Add(new Speaker(1, "Dr Paul", "paul@speakers.com", String.Empty, "This is a biography..."));

            BindingList<SeminarAttendee> attendeeList = new BindingList<SeminarAttendee>();
            attendeeList.Add(new SeminarAttendee(0, "Jason", "jason@attendee.com", "911"));
            attendeeList.Add(new SeminarAttendee(1, "Tyrone", "tyrone@attendee.com", "912"));


            DataInstance.seminars.Add(new Seminar(DataInstance.organisers[0], DataInstance.rooms[0], DataInstance.speakers,
                attendeeList, "Learning Python", "The Zen of Python", DateTime.Now, DateTime.Today));
            DataInstance.seminars.Add(new Seminar(DataInstance.organisers[0], DataInstance.rooms[0], DataInstance.speakers,
                attendeeList, "Learning C#", "Java developers wear glasses because they can't see sharp", DateTime.Now, DateTime.Today));

        }
    }
}
