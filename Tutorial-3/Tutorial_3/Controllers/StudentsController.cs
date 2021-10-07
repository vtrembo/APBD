using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tutorial_3.Models;
using Tutorial_3.Services;

namespace Tutorial_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public List<Student> _student = new List<Student>();

        [HttpGet]
        public IActionResult GetStudents()
        {
            ManagerCSV.ReadCSV(_student);
            return Ok(_student);
        }
        [HttpGet("indexNumber")]
        public IActionResult GetStudent(string indexNumber)
        {
            ManagerCSV.findByIndexNumber(_student, indexNumber);
            return Ok(_student);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (!Regex.IsMatch(student.indexNumber, @"s[0-9]+")) { return BadRequest("The indexNumber has invalid format."); }
            _student.Add(student);
            ManagerCSV.SaveToCSV(_student, false);
            return Ok(student);
        }
        [HttpPut("indexNumber")]
        public IActionResult UpdateStudent(string indexNumber, Student student)
        {
           _student = ManagerCSV.UpdateCSV(student, indexNumber);
            ManagerCSV.SaveToCSV(_student, true);
            return Ok(student);
        }
        [HttpDelete("indexNumber")]
        public IActionResult DeleteStudent(string indexNumber)
        {
            ManagerCSV.DeleteFromCSV(_student, indexNumber);
            ManagerCSV.SaveToCSV(_student, true);
            return Ok(_student);
        }
    }
}