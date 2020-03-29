using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzoftFejlesztes
{
    public sealed class UserData
    {
        private static UserData instance = null;
        private string name;
        private string city;
        private string tel;
        private int database_ID;
        private string email;
        private string password;
        public UserData()
        {
            Name = City = Email = password = tel = null;
            Database_ID = -1;
        }

        public int Database_ID { get => database_ID; set => database_ID = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Password { get => password; set => password = value; }

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
            Name = City = Email = password = tel = null;
            Database_ID = -1;
        }
    }
}
