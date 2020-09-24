using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Configurations
{
    public class OptionConfigurationBuilder : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder
              .Property(v => v.OptionId)
              .HasColumnName("Id")
              .IsRequired()
              .UseIdentityColumn(1, 1)
              .HasColumnType("int");

            builder
                .Property(v => v.OptionName)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder
                .Property(v => v.OptionDescription)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");
        }
    }
 
}
