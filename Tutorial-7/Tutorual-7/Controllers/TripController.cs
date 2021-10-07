using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorual_7.Exceptions;
using Tutorual_7.Models;
using Tutorual_7.Models.DTOs.Request;
using Tutorual_7.Service;

namespace Tutorual_7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripDbService _tripDbService;

        public TripController(ITripDbService tripDbService)
        {
            _tripDbService = tripDbService;
        }

        [HttpGet]
        public IActionResult TripList()
        {
            return Ok(_tripDbService.GetTripList());
        }
        [HttpDelete]
        public IActionResult DeleteClient(DeleteClientRequest request)
        {
            _tripDbService.DeleteClient(request);
            return Ok("Client has been deleted successfully");
        }
        [HttpPost(Name = "InsertClient")]
        public IActionResult InsertStudent(InsertClientRequest request)
        {
            try
            {
                var client = _tripDbService.InsertClient(request);
                return Created("InsertClient", client);
            }
            catch (StudiesNotFound ex1)
            {
                return NotFound(ex1.Message);
            }
            catch (ClientAlreadyExists ex2)
            {
                return BadRequest(ex2.Message);
            }
        }
    }
}
