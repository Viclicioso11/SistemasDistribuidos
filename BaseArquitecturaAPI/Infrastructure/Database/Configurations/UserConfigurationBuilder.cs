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
              .Property(v => v.UserId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder
                .Property(v => v.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder
                .Property(v => v.MiddleName)
                .HasColumnName("MiddleName")
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder
                .Property(v => v.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnType("varchar(15)");

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
