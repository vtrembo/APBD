using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorual_7.Exceptions
{
    public class ClientTripAlreadyExists : Exception
    {
        public ClientTripAlreadyExists () : base("Client is already signed up for the trip") { }
    }
}
