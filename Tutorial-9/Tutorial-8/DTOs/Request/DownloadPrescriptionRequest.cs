using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_8.DTOs.Request
{
    public class DownloadPrescriptionRequest
    {
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public string Medicament { get; set; }
    }
}
