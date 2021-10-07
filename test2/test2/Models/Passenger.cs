using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Models
{
    public class Passenger
    {
        public int IdPassenger { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNum { get; set; }

        public virtual ICollection<FlightPassenger> FlightPassengers { get; set; }

    }
}
