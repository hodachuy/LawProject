using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{

    public class LegalDocumentFileConfiguration : IEntityTypeConfiguration<LegalDocumentFile>
    {
        public void Configure(EntityTypeBuilder<LegalDocumentFile> builder)
        {
            builder.ToTable("LegalDocumentFiles");
            builder.HasKey(x => x.FileID);
            builder.Property(x => x.FileID).UseIdentityColumn();
            builder.Property(x => x.FileID).IsRequired();
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.LegalID).IsRequired();

            builder.HasOne<LegalDocument>(ad => ad.LegalDocument)
            .WithMany(x => x.LegalDocumentFiles)
            .HasForeignKey(ad => ad.LegalID);
        }
    }
}
