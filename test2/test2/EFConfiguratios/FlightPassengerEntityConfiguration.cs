using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;

namespace test2.EFConfiguratios
{
    public class FlightPassengerEntityConfiguration : IEntityTypeConfiguration<FlightPassenger>
    {
        public void Configure(EntityTypeBuilder<FlightPassenger> builder)
        {
            builder.ToTable("FlightPassenger");

            builder.HasKey(e => new { e.IdFlight, e.IdPassenger });


            builder.HasOne(e => e.flight)
                .WithMany(m => m.FlightPassengers)
                .HasForeignKey(m => m.IdFlight)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.passenger)
                .WithMany(m => m.FlightPassengers)
                .HasForeignKey(m => m.IdPassenger)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
