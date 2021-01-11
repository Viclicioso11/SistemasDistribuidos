using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class CountryConfigurationBuilder : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.CountryName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder
                .HasData(
                    new Country { Id = 1, CountryName = "Nicaragua" });
        }
    }
}
