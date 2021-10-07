
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Tutorial_4.Services.AnimalsMainService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IDatabaseService _dbService;

        public AnimalsController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public IActionResult GetAnimals(string ordered)
        {
            if (string.IsNullOrEmpty(ordered) || ordered == "name" || ordered == "description" || ordered == "category" || ordered == "area")
                return Ok(_dbService.GetAnimals(ordered));
            else return BadRequest("Parameter is not correct.");
        }
        [HttpPost]
        public IActionResult AddAnimals(Animal animal)
        {
            return Ok(_dbService.AddAnimals(animal));
        }
        [HttpPut]
        public IActionResult UpdateAnimals(Animal animal, int idAnimal)
        {
            if (_dbService.animalExists(idAnimal)) 
                return Ok(_dbService.UpdateAnimals(animal, idAnimal));
            else return NotFound("Animal with such ID was not found.");
        }
        [HttpDelete]
        public IActionResult DeleteAnimals(int idAnimal)
        {

            if (_dbService.animalExists(idAnimal))
            {
                _dbService.DeleteAnimals(idAnimal);
                return Ok();
            }   
            else return NotFound("Animal with such ID was not found.");
        }
    }
}