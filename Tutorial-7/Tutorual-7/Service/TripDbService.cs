using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorual_7.Exceptions;
using Tutorual_7.Models;
using Tutorual_7.Models.DTOs.Request;

namespace Tutorual_7.Service
{
    public class TripDbService : ITripDbService
    {
        private TripDbContext  _context;
        public TripDbService (TripDbContext context)
        {
            _context = context;
        }
        public List<Trip> GetTripList()
        {
            List<Trip> TripList = _context.Trips.ToList();
            return TripList;
        }
        public void DeleteClient(DeleteClientRequest request)
        {
            var client = _context.Clients.Find(request.IndexNumber);
            if (client == null)
            {
                throw new ClientNotFound();
            }
            _context.Remove(client);
            _context.SaveChanges();
        }
        public InsertClientResponse InsertStudent(InsertClientRequest request)
        {
            var trip = _context.Trips.FirstOrDefault(t => t.IdTrip == request.IdTrip);
            if (trip == null)  {  throw new TripNotFound();  }
            var pesel = _context.Clients.FirstOrDefault(c => c.Pesel == request.Pesel);
            if (pesel == null) 
            {
                var Client = new Client()
                {
                    IdClient = _context.Clients.Max(cl => cl.IdClient) + 1,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Telephone = request.Telephone,
                    Pesel = request.Pesel
                };
                _context.Clients.Add(Client);
            };
            var client = _context.Clients.FirstOrDefault(c => c.Pesel == request.Pesel);
            if (_context.ClientTrips.FirstOrDefault(c => c.IdClient == client.IdClient && c.IdTrip == request.IdTrip) != null)
            {
                throw new ClientTripAlreadyExists();
            }
            var clientTrip = _context.ClientTrips.Where(clt =>clt.IdTrip == trip.IdTrip).FirstOrDefault();
            if (clientTrip == null)
            {
                clientTrip = new ClientTrip()
                {
                    IdTrip = trip.IdTrip,
                    PaymentDate = DateTime.Now
                };
                _context.ClientTrips.Add(clientTrip);
            }

            return;
        }

    }
}
