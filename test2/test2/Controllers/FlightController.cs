using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Servicies;

namespace test2.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IDbService _dbService;
        public FlightController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("passenger/{idPassenger}")]
        public async Task<IActionResult> GetPassengerFlights(int idPassenger)
        {
            return await _dbService.GetFlights(idPassenger);
        }
        [HttpPost("passenger/{idPassenger}/flight/{idFlight}")]
        public async Task<IActionResult> AssignPassengerToFlight(int idPassenger, int idFlight)
        {
            return await _dbService.RegisterPassenger(idPassenger, idFlight);
        }
    }
}
