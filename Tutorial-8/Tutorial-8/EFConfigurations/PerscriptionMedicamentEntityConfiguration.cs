using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_8.Models;

namespace Tutorial_8.EFConfigurations
{
    public class PerscriptionMedicamentEntityConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("PerscriptionMedicament");

            builder.HasKey(e => new { e.IdPrescription, e.IdMedicament });

            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Prescription)
                .WithMany(m => m.PrescrptionMedicaments)
                .HasForeignKey(m => m.IdPrescription)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Medicament)
                .WithMany(m => m.PrescrptionMedicaments)
                .HasForeignKey(m => m.IdMedicament)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
