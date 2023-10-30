using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    public interface IUser
    {
     //Lägg till properties
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
    }
   
}
