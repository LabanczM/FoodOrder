using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPincerV2
{
    public sealed class UserData
    {
        private static UserData instance = null;
        private string name;
        private string city;
        private string date;
        private string tel;
        private string driver_l;
        private int database_ID;
        private string email;
        private string password;
        private bool availability;

        public UserData()
        {
            availability = false;
            Name = City = Email = password = Date = tel = driver_l = null;
            Database_ID = -1;
        }

        public int Database_ID { get => database_ID; set => database_ID = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Email { get => email; set => email = value; }
        public string Date { get => date; set => date = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Driver_L { get => driver_l; set => driver_l = value; }
        public string Password { get => password; set => password = value; }
        public bool Availability { get => availability; set => availability = value; }

        public static UserData GetInstance()
        {
            if (instance == null)
            {
                instance = new UserData();
            }
            return instance;
        }

        public void SetDefault()
        {
            availability = false;
            Name = City = Email = password = Date = tel = driver_l = null;
            Database_ID = -1;
        }
    }
}
