using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;

namespace test2.EFConfiguratios
{
    public class PassengerEntityConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("Passenger");

            builder.HasKey(e => e.IdPassenger);
            builder.Property(e => e.IdPassenger).ValueGeneratedOnAdd();


            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(60);
            builder.Property(e => e.PassportNum).IsRequired().HasMaxLength(20);
        }
    }
}
