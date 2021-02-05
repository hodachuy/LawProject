using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class DocumentsTypeConfiguration : IEntityTypeConfiguration<DocumentsType>
    {
        public void Configure(EntityTypeBuilder<DocumentsType> builder)
        {
            builder.ToTable("DocumentsTypes");
            builder.HasKey(x => x.DocID);
            builder.Property(x => x.DocID).UseIdentityColumn();
            builder.Property(x => x.DocID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);
        }
    }
}
