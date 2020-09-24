using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class CityConfigurationBuilder : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
              .Property(v => v.CityId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.CityName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder
                .Property(v => v.CityCode)
                .HasColumnName("Code")
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder
               .HasOne(v => v.State)
               .WithMany(v => v.Cities)
               .IsRequired()
               .HasConstraintName("FkStateId");

            builder
                .HasData(
                new City { CityId = 1, CityName = "Boaco", CityCode = "361", StateId = 1 });
        }
    }
}
