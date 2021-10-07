using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_8.DTOs.Request;
using Tutorial_8.Services;

namespace Tutorial_8.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicDbService _dbService;
        public ClinicController(IClinicDbService ClinicDbService)
        {
            _dbService = ClinicDbService;
        }
        [HttpGet("doctor")]
        public async Task<IActionResult> GetDoctor()
        {
            return await _dbService.GetDoctors();
        }
        [HttpPost("doctor")]
        public async Task<IActionResult> AddDoctor(AddDoctorRequest request) {
            return await _dbService.AddDoctor(request);
        }
        [HttpDelete("doctor/{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int IdDoctor)
        {
            return await _dbService.DeleteDoctor(IdDoctor);
        }
        [HttpPut("doctor/{idDoctor}")]
        public async Task<IActionResult> ModifyDoctor(ModifyDoctorRequest request)
        {
            return await _dbService.ModifyDoctor(request);
        }

        [HttpGet("prescription")]
        public async Task<IActionResult> GetPrescription(DownloadPrescriptionRequest request)
        {
            return await _dbService.GetPrescription(request);
        }
    }
}
