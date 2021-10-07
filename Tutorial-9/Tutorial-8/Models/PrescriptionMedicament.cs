using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_8.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public Medicament Medicament { get; set; }
        public int IdPrescription { get; set; }
        public Prescription Prescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}
