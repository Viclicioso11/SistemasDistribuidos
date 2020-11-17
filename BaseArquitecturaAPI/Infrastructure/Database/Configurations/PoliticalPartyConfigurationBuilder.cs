using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class PoliticalPartyConfigurationBuilder : IEntityTypeConfiguration<PoliticalParty>
    {
        public void Configure(EntityTypeBuilder<PoliticalParty> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.PoliticalPartyName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar(60)");

            builder
                .Property(v => v.Abreviation)
                .HasColumnName("Abreviation")
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("varchar(6)");
        }
    }
}
