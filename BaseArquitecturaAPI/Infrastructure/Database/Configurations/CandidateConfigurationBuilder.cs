using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class CandidateConfigurationBuilder : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder
              .Property(v => v.CandidateId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar");

            builder
                .Property(v => v.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar");

            builder
                .Property(v => v.MiddleName)
                .HasColumnName("MiddleName")
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnType("varchar");

            builder
                .Property(v => v.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnType("varchar");

            builder
                .Property(v => v.Status)
                .HasColumnName("Status")
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("int");

            builder
               .HasOne(v => v.PoliticalParty)
               .WithMany(v => v.Candidates)
               .IsRequired()
               .HasConstraintName("FkPoliticalPartyId");
        }
    }
}
