using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    public class Travel
    {
       
        public string CityTwo { get; set; }
        
        public Country countryTo { get; set; }

        public int travelers  { get; set; }

        public Travel(string cityTwo, Country countryTo, int travelers)
        {
            CityTwo = cityTwo;
            this.countryTo = countryTo;
            this.travelers = travelers;
        }

        virtual public string GetInfo()
        {
            return $"Destination: {CityTwo} in {countryTo}, {travelers} travelers registered";
        }
         







    }
}
