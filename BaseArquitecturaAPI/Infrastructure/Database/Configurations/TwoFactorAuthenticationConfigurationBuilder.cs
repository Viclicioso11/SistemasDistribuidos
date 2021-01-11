using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class TwoFactorAuthenticationConfigurationBuilder : IEntityTypeConfiguration<TwoFactorAuthentication>
    {
        public void Configure(EntityTypeBuilder<TwoFactorAuthentication> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .Property(v => v.Attempts)
               .HasColumnName("Attempts")
               .IsRequired()
               .HasMaxLength(2)
               .HasColumnType("int");

            builder
               .Property(v => v.OneTimePassword)
               .HasColumnName("OneTimePassword")
               .IsRequired()
               .HasMaxLength(10)
               .HasColumnType("varchar(10)");

            builder
               .Property(v => v.ExpirationDate)
               .HasColumnName("ExpirationDate")
               .IsRequired()
               .HasColumnType("datetime");

            builder
                .Property(v => v.Status)
                .HasColumnName("Status")
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnType("int");

            builder
               .HasOne(v => v.User)
               .WithMany(v => v.TwoFactorAuthentications)
               .HasForeignKey(v => v.UserId)
               .IsRequired()
               .HasConstraintName("FkTFAUserId");

        }
    }
}
