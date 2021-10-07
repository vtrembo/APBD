using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_8.Models;

namespace Tutorial_8.Services
{
    public static class CustomExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { IdDoctor = 1, FirstName = "Max", LastName = "Tell", Email = "nsdas@masda.com" },
                new Doctor() { IdDoctor = 2, FirstName = "Dim", LastName = "Hell", Email = "gfd435@ma2a.com" }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { IdPatient = 1, FirstName = "Loop", LastName = "Demver", BirthDate = DateTime.Now },
                new Patient() { IdPatient = 2, FirstName = "Larry", LastName = "Kris", BirthDate = DateTime.Now }

                );

            modelBuilder.Entity<Prescription>().HasData(
                new Models.Prescription() { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now, IdDoctor = 1, IdPatient = 1 },
                new Models.Prescription() { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now, IdDoctor = 1, IdPatient = 2 }

                );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament() { IdMedicament = 1, Name = "Something", Description = "Good", Type = "Lalala" }
                );
            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament() { IdMedicament = 1, IdPrescription = 1, Details = "For best guys" }
                );
        }
    }
}
