using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class LegalDocumentGroupConfiguration : IEntityTypeConfiguration<LegalDocumentGroup>
    {
        public void Configure(EntityTypeBuilder<LegalDocumentGroup> builder)
        {
            builder.ToTable("LegalDocumentGroups");
            builder.HasKey(x => x.LegalGroupID);
            builder.Property(x => x.LegalGroupID).UseIdentityColumn();
            builder.Property(x => x.LegalGroupID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);
        }
    }
}
