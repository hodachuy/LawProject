using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class LegalDocumentConfiguration : IEntityTypeConfiguration<LegalDocument>
    {
        public void Configure(EntityTypeBuilder<LegalDocument> builder)
        {
            builder.ToTable("LegalDocuments");
            builder.HasKey(x => x.LegalID);
            builder.Property(x => x.LegalID).UseIdentityColumn();
            builder.Property(x => x.LegalID).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.IsDelete).HasDefaultValue(false);
            builder.Property(x => x.IsPublish).HasDefaultValue(false);
            builder.Property(x => x.IsTraining).HasDefaultValue(false);
            builder.Property(x => x.LegalGroupID).IsRequired();
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.IsHasAppendix).HasDefaultValue(false);
            builder.Property(x => x.StatusValue).IsRequired();

            builder.HasOne<LegalDocumentGroup>(ad => ad.LegalDocumentGroup)
                .WithMany(x => x.LegalDocuments)
                .HasForeignKey(ad => ad.LegalGroupID);

            builder.HasOne<Area>(ad => ad.Area)
                .WithMany(x => x.LegalDocuments)
                .HasForeignKey(ad => ad.AreaID);

            builder.HasOne<Editor>(ad => ad.Editor)
                .WithMany(x => x.LegalDocuments)
                .HasForeignKey(ad => ad.EditorID);

            builder.HasOne<DocumentsType>(ad => ad.DocumentsType)
                .WithMany(x => x.LegalDocuments)
                .HasForeignKey(ad => ad.DocTypeID);

            builder.HasOne<Agency>(ad => ad.Agency)
                .WithMany(x => x.LegalDocuments)
                .HasForeignKey(ad => ad.AgencyID);

            builder.HasOne<LegalDocumentType>(ad => ad.LegalDocumentType)
                .WithMany(x => x.LegalDocuments)
                .HasForeignKey(ad => ad.LegalTypeID);

            builder.HasMany<Part>(ad => ad.Parts)
                .WithOne(x => x.LegalDocument)
                .HasForeignKey(ad => ad.PartID);
        }
    }
}
