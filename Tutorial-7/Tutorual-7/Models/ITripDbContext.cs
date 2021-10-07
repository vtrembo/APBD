using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorual_7.Models
{
    public interface ITripDbContext
    {
         DbSet<Client> Clients { get; set; }
         DbSet<ClientTrip> ClientTrips { get; set; }
         DbSet<Country> Countries { get; set; }
         DbSet<CountryTrip> CountryTrips { get; set; }
         DbSet<Trip> Trips { get; set; }
    }
}
