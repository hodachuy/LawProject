using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("Chapters");
            builder.HasKey(x => x.ChapID);
            builder.Property(x => x.ChapID).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.LegalID).IsRequired();
            builder.Property(x => x.PartID).IsRequired();
            builder.Property(x => x.Idx).HasDefaultValue(0);
        }
    }
}
