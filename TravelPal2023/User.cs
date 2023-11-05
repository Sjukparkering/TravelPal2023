using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public List<Travel> Travels { get; set; } = new();

        public User(string username, string password, Country country)
        {
            Username = username;
            Password = password;
            Location = country;
        }
    }


}
