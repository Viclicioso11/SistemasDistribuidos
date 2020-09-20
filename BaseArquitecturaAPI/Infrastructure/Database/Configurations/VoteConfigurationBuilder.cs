using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class VoteConfigurationBuilder : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder
              .Property(v => v.VoteId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
               .HasOne(v => v.User)
               .WithMany(v => v.Votes)
               .IsRequired()
               .HasConstraintName("FkUserVoteId");

            builder
               .HasOne(v => v.Candidate)
               .WithMany(v => v.Votes)
               .IsRequired()
               .HasConstraintName("FkCandidateVoteId");
        }
    }

}
