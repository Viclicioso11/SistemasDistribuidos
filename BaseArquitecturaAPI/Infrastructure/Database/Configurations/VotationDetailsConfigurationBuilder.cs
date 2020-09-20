using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class VotationDetailsConfigurationBuilder : IEntityTypeConfiguration<VotationDetail>
    {
        public void Configure(EntityTypeBuilder<VotationDetail> builder)
        {
            builder
              .Property(v => v.VotationDetailId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .HasOne(v => v.Votation)
               .WithMany(v => v.VotationDetails)
               .IsRequired()
               .HasConstraintName("FkDVotationId");

            builder
               .HasOne(v => v.Candidate)
               .WithMany(v => v.VotationDetails)
               .IsRequired()
               .HasConstraintName("FkCandidateId");
        }
    }
}
