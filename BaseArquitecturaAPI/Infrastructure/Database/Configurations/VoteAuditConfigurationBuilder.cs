using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class VoteAuditConfigurationBuilder : IEntityTypeConfiguration<VoteAudit>
    {
        public void Configure(EntityTypeBuilder<VoteAudit> builder)
        {
            builder
              .Property(v => v.VoteAuditId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .HasOne(v => v.User)
               .WithMany(v => v.VoteAudits)
               .IsRequired()
               .HasConstraintName("FkVAUserId");

            builder
               .HasOne(v => v.Votation)
               .WithMany(v => v.VoteAudits)
               .IsRequired()
               .HasConstraintName("FkAVotationId");
        }
    }
}
