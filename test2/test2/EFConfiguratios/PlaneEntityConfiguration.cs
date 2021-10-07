using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;

namespace test2.EFConfiguratios
{
    public class PlaneEntityConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.ToTable("Plane");

            builder.HasKey(e => e.IdPlane);
            builder.Property(e => e.IdPlane).ValueGeneratedOnAdd();


            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MaxSeats).IsRequired();
        }
    }
}
