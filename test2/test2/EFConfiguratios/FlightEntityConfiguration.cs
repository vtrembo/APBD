using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;

namespace test2.EFConfiguratios
{
    public class FlightEntityConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flight");

            builder.HasKey(e => e.IdFlight);
            builder.Property(e => e.IdFlight).ValueGeneratedOnAdd();

            builder.Property(e => e.FlightDate).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.Comments).HasMaxLength(200);

            builder.HasOne(e => e.plane)
               .WithMany(p => p.Flights)
               .HasForeignKey(p => p.IdPlane)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(e => e.cityDict)
                .WithMany(d => d.Flights)
                .HasForeignKey(d => d.IdCityDict)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
