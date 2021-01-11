using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class CandidateAuditConfigurationBuilder : IEntityTypeConfiguration<CandidateAudit>
    {
        public void Configure(EntityTypeBuilder<CandidateAudit> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .Property(v => v.CandidateStatusChangedTo)
               .HasColumnName("StatusChangedTo")
               .HasMaxLength(2)
               .HasColumnType("int");

            builder
               .Property(v => v.StatusChangedAt)
               .HasColumnName("StatusChangedAt")
               .HasColumnType("datetime")
               .IsRequired(false);

            builder
               .Property(v => v.CreatedAt)
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime")
               .IsRequired(false);

            builder
               .HasOne(v => v.ChangesMadeByUser)
               .WithMany(v => v.CandidateAudits)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired()
               .HasConstraintName("FkCandidateChangesMadeByUserId");
        }
    }
}
