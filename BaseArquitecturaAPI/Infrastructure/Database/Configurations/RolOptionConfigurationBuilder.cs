using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class RolOptionConfigurationBuilder : IEntityTypeConfiguration<RolOption>
    {
        public void Configure(EntityTypeBuilder<RolOption> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .HasOne(v => v.Rol)
               .WithMany(v => v.RolOptions)
               .IsRequired()
               .HasConstraintName("FkRolId");

            builder
               .HasOne(v => v.Option)
               .WithMany(v => v.RolOptions)
               .IsRequired()
               .HasConstraintName("FkOptionId");
        }
    }
}
