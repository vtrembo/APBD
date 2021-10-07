using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorual_7.Exceptions
{
    public class TripNotFound : Exception
    {
        public TripNotFound() : base("Trip not found") { }
    }
}
