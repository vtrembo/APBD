using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.DTOs.Response;
using test2.Models;

namespace test2.Servicies
{
    public interface IDbService
    {
        public Task<IActionResult> GetFlights(int idP);
        public Task<IActionResult> RegisterPassenger(int idP, int idF);

    }
    public class MainDbService : IDbService
    {
        private IMainDbContext _context;

        public MainDbService(IMainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetFlights(int idP)
        {
            if (!await CheckPassenger(idP)) return new BadRequestObjectResult($"Passenger {idP} does not exist");


            var flightPassenger = await  _context.FlightPassengers
                .Where(fp => fp.IdPassenger == idP)
                .SingleOrDefaultAsync();

            var flights = await _context.Flights
               .Where(f => f.IdFlight == flightPassenger.IdFlight)
               .SingleOrDefaultAsync();

            var city = await _context.CityDict
                 .Where(c => c.IdCityDict == flights.IdCityDict)
                 .SingleOrDefaultAsync();

            var plane = await _context.Planes
                 .Where(c => c.IdPlane == flights.IdPlane)
                 .SingleOrDefaultAsync();

            var response = new PssengerFlightResponse()
            {
                CityName = city.City,
                FlyObject = plane.Name
            };

            return new OkObjectResult(response);
        }

        public async Task<IActionResult> RegisterPassenger(int idP, int idF)
        {
               if (!await CheckFlight(idF)) return new BadRequestObjectResult($"Flight {idF} does not exist");
               if (await CheckAlreadyRegistered(idF, idP)) return new BadRequestObjectResult($"Passenger {idP} is already registered to flight {idF}");


            var flightPassenger = new FlightPassenger()
            {
                IdFlight = idF,
                IdPassenger = idP  
            };

            await _context.FlightPassengers.AddAsync(flightPassenger);
            await _context.SaveChangesAsync();
            return new OkObjectResult($"Passenger {idP} was register to flight {idF}");
        }

        private async Task<bool> CheckPassenger(int id)
        {
            return await _context.Passengers
                .AnyAsync(p => p.IdPassenger == id);
        }
        private async Task<bool> CheckFlight(int id)
        {
            return await _context.Flights
                .AnyAsync(p => p.IdFlight == id);
        }
        private async Task<bool> CheckAlreadyRegistered(int idF, int idP)
        {
            return await _context.FlightPassengers
                .Where(f => f.IdFlight == idF)
                .AnyAsync(f => f.IdPassenger == idP);
        }
    }
}
