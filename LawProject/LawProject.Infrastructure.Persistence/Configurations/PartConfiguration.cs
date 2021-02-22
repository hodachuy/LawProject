using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("Parts");
            builder.HasKey(x => x.PartID);
            builder.Property(x => x.PartID).UseIdentityColumn();
            builder.Property(x => x.PartID).IsRequired();
            builder.Property(x => x.IsDelete).HasDefaultValue(false);
            builder.Property(x => x.LegalID).IsRequired();
            builder.Property(x => x.Idx).HasDefaultValue(0);

            builder.HasOne<LegalDocument>(ad => ad.LegalDocument)
                .WithMany(x => x.Parts)
                .HasForeignKey(ad => ad.LegalID);
        }
    }
}
