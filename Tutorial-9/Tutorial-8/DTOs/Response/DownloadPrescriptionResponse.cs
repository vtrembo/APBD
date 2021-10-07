using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_8.DTOs.Response
{
    public class DownloadPrescriptionResponse
    {
        public string Medicament { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
    }
}
