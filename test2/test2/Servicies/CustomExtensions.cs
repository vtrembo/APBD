using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;

namespace test2.Servicies
{
    public static class CustomExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityDict>().HasData(
               new CityDict() { IdCityDict = 1, City = "Warsaw" },
               new CityDict() { IdCityDict = 2, City = "Odessa" }

               );

            modelBuilder.Entity<Plane>().HasData(
                new Plane() { IdPlane = 1, Name = "Bojong", MaxSeats = 56 },
                new Plane() { IdPlane = 2, Name = "QouterPlus", MaxSeats = 34 }

                );

            modelBuilder.Entity<Models.Flight>().HasData(
                new Models.Flight() { IdFlight = 1, FlightDate = DateTime.Now, Comments = null, IdPlane = 1, IdCityDict = 1 },
                new Models.Flight() { IdFlight = 2, FlightDate = DateTime.Now, Comments = null, IdPlane = 2, IdCityDict = 2 }
                );

                        modelBuilder.Entity<Passenger>().HasData(
                new Passenger() { IdPassenger = 1, FirstName = "Valerii", LastName = "Trembovetsky", PassportNum = "Not today" },
                new Passenger() { IdPassenger = 2, FirstName = "Kris", LastName = "Delamoi", PassportNum = "LD232954" }
                );

            modelBuilder.Entity<FlightPassenger>().HasData(
                new FlightPassenger() { IdFlight = 1, IdPassenger = 1 }
                );
        }
     }
}
