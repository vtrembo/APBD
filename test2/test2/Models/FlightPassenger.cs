using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Models
{
    public class FlightPassenger
    {
        public int IdFlight { get; set; }
        public Flight flight { get; set; }
        public int IdPassenger { get; set; }
        public Passenger passenger { get; set; }
    }
}
