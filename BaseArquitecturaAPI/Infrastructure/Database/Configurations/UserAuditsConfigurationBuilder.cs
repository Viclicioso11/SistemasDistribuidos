using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class UserAuditsConfigurationBuilder : IEntityTypeConfiguration<UserAudit>
    {
        public void Configure(EntityTypeBuilder<UserAudit> builder)
        {
            builder
              .Property(v => v.UserAuditId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.UserStatusChangedTo)
                .HasColumnName("StatusChangedTo")
                .HasMaxLength(2)
                .HasColumnType("int");

            builder
                .Property(v => v.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder
                .Property(v => v.StatusChangedAt)
                .HasColumnName("StatusChangedAt")
                .HasColumnType("datetime");

            builder
                .Property(v => v.LastLogin)
                .HasColumnName("LastLogin")
                .HasColumnType("datetime");

            builder
                .Property(v => v.ChangeMadeAt)
                .HasColumnName("ChangeMadeAt")
                .HasColumnType("datetime");

            builder
                .Property(v => v.LastEmail)
                .HasColumnName("LastEmail")
                .HasMaxLength(20)
                .HasColumnType("varchar");

            builder
                .Property(v => v.LastPassword)
                .HasColumnName("LastPassword")
                .HasMaxLength(20)
                .HasColumnType("varchar");

            builder
               .HasOne(v => v.UserChanged)
               .WithMany(v => v.UserChangedAudits)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired()
               .HasConstraintName("FkUserChangedId");
               

            builder
               .HasOne(v => v.ChangesMadeByUser)
               .WithMany(v => v.UserThatChangeAudits)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired()
               .HasConstraintName("FkChangesMadeByUserId");

        }
    }
}
