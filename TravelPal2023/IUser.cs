using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    public interface IUser
    {
        public string username { get; set; }
        public string password { get; set; }
        public Country country { get; set; }
    }
}
