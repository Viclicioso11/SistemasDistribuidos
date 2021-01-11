using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class UserRolConfigurationBuilder : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .HasOne(v => v.Rol)
               .WithMany(v => v.UserRols)
               .IsRequired()
               .HasConstraintName("FkURolId");

            builder
               .HasOne(v => v.User)
               .WithMany(v => v.UserRols)
               .IsRequired()
               .HasConstraintName("FkRUserId");
        }
    }
    
}
