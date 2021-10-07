using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_8.Models;

namespace Tutorial_8.EFConfigurations
{
    public class PerscriptionEntityConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");

            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

            builder.Property(e => e.Date).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.DueDate).IsRequired().HasColumnType("datetime");

            builder.HasOne(e => e.Patient)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(m => m.IdPatient)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Doctor)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(m => m.IdDoctor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
