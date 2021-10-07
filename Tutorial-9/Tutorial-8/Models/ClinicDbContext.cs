using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tutorial_8.EFConfigurations;
using Tutorial_8.Services;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Tutorial_8.Models
{
    public interface IClinicDbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
    public class ClinicDbContext : DbContext, IClinicDbContext
    {
        private IConfiguration _configuration;
        public ClinicDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ClinicDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProductionDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PerscriptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PerscriptionMedicamentEntityConfiguration());

            modelBuilder.Seed();
        }
    }
}