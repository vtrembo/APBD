using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Models
{
    public class CityDict
    {
        public int IdCityDict { get; set; }
        public string City { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
