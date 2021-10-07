using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Models
{
    public class Flight
    {

        public int IdFlight { get; set; }

        public DateTime FlightDate { get; set; }
        public string Comments { get; set; }

        public int IdPlane { get; set; }
        public Plane plane { get; set; }
        public int IdCityDict { get; set; }
        public CityDict cityDict { get; set; }
        public virtual ICollection<FlightPassenger> FlightPassengers { get; set; }
    }
}
