using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class LegalDocumentTypeConfiguration : IEntityTypeConfiguration<LegalDocumentType>
    {
        public void Configure(EntityTypeBuilder<LegalDocumentType> builder)
        {
            builder.ToTable("LegalDocumentTypes");
            builder.HasKey(x => x.LegalTypeID);
            builder.Property(x => x.LegalTypeID).UseIdentityColumn();
            builder.Property(x => x.LegalTypeID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(350);
        }
    }
}
