using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class RolConfigurationBuilder : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.RolName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder
                .HasData(
                new Rol { Id = 1, RolName = "Admin" },
                new Rol { Id = 2, RolName = "User" }
                );
        }
    }
}
