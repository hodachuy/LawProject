using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class LawOfficeConfiguration : IEntityTypeConfiguration<LawOffice>
    {
        public void Configure(EntityTypeBuilder<LawOffice> builder)
        {
            builder.ToTable("LawOffices");
            builder.HasKey(x => x.LawOfficeID);
            builder.Property(x => x.LawOfficeID).UseIdentityColumn();
            builder.Property(x => x.LawOfficeID).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.Email).IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.IsPublished).HasDefaultValue(false);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(350);
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.Website).IsUnicode(false);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);
        }
    }
}
