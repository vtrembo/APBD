using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorual_7.Exceptions
{
    public class ClientAlreadyExists : Exception
    {
        public ClientAlreadyExists () : base("Client already exists") { }
    }
}
