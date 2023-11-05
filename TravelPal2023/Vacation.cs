using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    class Vacation: Travel

    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive, string cityTwo, Country cbCountryTo, int travelers) : base( cityTwo, cbCountryTo, travelers)
        {
            AllInclusive = allInclusive; 
        }

        public override string GetInfo()
        {
            return $"Destination: {CityTwo} in {countryTo}, {travelers} travelers registered, all inclusive included: {AllInclusive}";
        }
    }
}
