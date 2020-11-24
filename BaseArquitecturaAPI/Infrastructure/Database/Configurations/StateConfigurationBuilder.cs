using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class StateConfigurationBuilder : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.StateName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder
               .HasOne(v => v.Country)
               .WithMany(v => v.States)
               .IsRequired()
               .HasConstraintName("FkCountryId");

            builder
                .HasData(
                new State { Id = 1, StateName = "Boaco", CountryId = 1 },
                new State { Id = 2, StateName = "Carazo", CountryId = 1 },
                new State { Id = 3, StateName = "Chinandega", CountryId = 1 },
                new State { Id = 4, StateName = "Chontales", CountryId = 1 },
                new State { Id = 5, StateName = "Estelí", CountryId = 1 },
                new State { Id = 6, StateName = "Granada", CountryId = 1 },
                new State { Id = 7, StateName = "Jinotega", CountryId = 1 },
                new State { Id = 8, StateName = "León", CountryId = 1 },
                new State { Id = 9, StateName = "Madriz", CountryId = 1 },
                new State { Id = 10, StateName = "Managua", CountryId = 1 },
                new State { Id = 11, StateName = "Masaya", CountryId = 1 },
                new State { Id = 12, StateName = "Matagalpa", CountryId = 1 },
                new State { Id = 13, StateName = "Nueva Segovia", CountryId = 1 },
                new State { Id = 14, StateName = "Río San Juan", CountryId = 1 },
                new State { Id = 15, StateName = "Rivas", CountryId = 1 },
                new State { Id = 16, StateName = "Defecto", CountryId = 1 }

                );
        }
    }
}
