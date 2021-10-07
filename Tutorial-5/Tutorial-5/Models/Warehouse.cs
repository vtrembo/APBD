using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Tutorial_5.Models
{
    public class Warehouse 
    {
        [Required]
        public int IdWarehouse { get; set; }
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}