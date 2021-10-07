using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;

namespace test2.EFConfiguratios
{
    public class CityDictEntityConfiguration : IEntityTypeConfiguration<CityDict>
    {
        public void Configure(EntityTypeBuilder<CityDict> builder)
        {
            builder.ToTable("CityDict");

            builder.HasKey(e => e.IdCityDict);
            builder.Property(e => e.IdCityDict).ValueGeneratedOnAdd();


            builder.Property(e => e.City).IsRequired().HasMaxLength(30);
        }
    }
}
