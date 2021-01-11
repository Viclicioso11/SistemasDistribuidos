using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class VotationAuditConfiguration : IEntityTypeConfiguration<VotationAudit>
    {
        public void Configure(EntityTypeBuilder<VotationAudit> builder)
        {
            builder
              .Property(v => v.Id)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .Property(v => v.VotationStatusChangedTo)
               .HasColumnName("VotationStatusChangedTo")
               .HasColumnType("int");

            builder
               .Property(v => v.CreatedAt)
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime")
               .IsRequired(false);

            builder
               .HasOne(v => v.Votation)
               .WithMany(v => v.VotationAudits)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired()
               .HasConstraintName("FkVotationId");

            builder
               .HasOne(v => v.ChangesMadeByUser)
               .WithMany(v => v.VotationAudits)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired()
               .HasConstraintName("FkVotationChangesMadeByUserId");
        }
    }
}
