using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class UserConfigurationBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.LastNames)
                .HasColumnName("LastNames")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder
                .Property(v => v.Names)
                .HasColumnName("Names")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder
                .Property(v => v.Status)
                .HasColumnName("Status")
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnType("int");

            builder
                .Property(v => v.Email)
                .HasColumnName("Email")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .Property(v => v.Identification)
                .HasColumnName("Identification")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder
                .Property(v => v.Password)
                .HasColumnName("Password")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("varchar(20)");

        }
    }
}
