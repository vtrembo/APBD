using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Models
{
    public class Plane
    {
        public int IdPlane { get; set; }
        public string Name { get; set; }
        public int MaxSeats { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
