using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Tutorual_7.Models.DTOs.Request
{
    public class InsertClientRequest
    {

        [Required(ErrorMessage = "Provide first name of client")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Provide last name of client")]
        [MaxLength(100)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Pesel { get; set; }
        public int IdTrip { get; set; }
        public string TripName { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
