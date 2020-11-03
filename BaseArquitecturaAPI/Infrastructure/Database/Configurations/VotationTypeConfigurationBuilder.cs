using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class VotationTypeConfigurationBuilder : IEntityTypeConfiguration<VotationType>
    {
        public void Configure(EntityTypeBuilder<VotationType> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.VotationTypeName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder
                .Property(v => v.VotationTypeDescription)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(200)");

            builder
                .HasData(new VotationType
                {
                    Id = 1,
                    VotationTypeName = "Alcaldía",
                    VotationTypeDescription = "Votaciones municipales"
                });

        }
    }
}
