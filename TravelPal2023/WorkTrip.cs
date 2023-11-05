using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal2023
{
    class WorkTrip: Travel
    {

        
            public string MeetingDet { get; set; }

            public WorkTrip(string WriteDetailsOfTrip, string cityTwo, Country cbCountryTo, int travelers) : base(cityTwo, cbCountryTo, travelers)
            {
              MeetingDet = WriteDetailsOfTrip;

            }

        public override string GetInfo()
        {
            return $"Destination: {CityTwo} in {countryTo}, {travelers} travelers registered,{MeetingDet}";
        }
    }
}

