using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class VotationConfiguration : IEntityTypeConfiguration<Votation>
    {
        public void Configure(EntityTypeBuilder<Votation> builder)
        {
            builder
              .Property(v => v.VotationId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.VotationDescription)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder
                .Property(v => v.VotationStatus)
                .HasColumnName("Status")
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("int");

            builder
                .Property(v => v.VotationStartDate)
                .HasColumnName("StartDate")
                .IsRequired()
                .HasColumnType("datetime");

            builder
                .Property(v => v.VotationEndDate)
                .HasColumnName("EndDate")
                .IsRequired()
                .HasColumnType("datetime");

            builder
                .HasOne(v => v.VotationType)
                .WithMany(v => v.Votations)
                .IsRequired()
                .HasConstraintName("FkVotationTypeId");

                
        }
    }
}
