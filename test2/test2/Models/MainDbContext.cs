using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using test2.EFConfiguratios;
using test2.Servicies;

namespace test2.Models
{

    public interface IMainDbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers{ get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<CityDict> CityDict { get; set; }
        public DbSet<FlightPassenger> FlightPassengers{ get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class MainDbContext : DbContext, IMainDbContext
    {
        private IConfiguration _configuration;

        public MainDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MainDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<CityDict> CityDict { get; set; }
        public DbSet<FlightPassenger> FlightPassengers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProductionDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityDictEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FlightEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FlightPassengerEntityConfiguration());
            
            modelBuilder.Seed();
        }
    }
}
