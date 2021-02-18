using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class LegalDocumentRelateConfiguration : IEntityTypeConfiguration<LegalDocumentRelate>
    {
        public void Configure(EntityTypeBuilder<LegalDocumentRelate> builder)
        {
            builder.ToTable("LegalDocumentRelates");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.LegalRelateID).IsRequired();
            builder.Property(x => x.LegalSourceID).IsRequired();
            builder.Property(x => x.LegalTypeID).IsRequired();
        }
    }
}
