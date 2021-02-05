using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class EditorConfiguration : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.ToTable("Editors");
            builder.HasKey(x => x.EditorID);
            builder.Property(x => x.EditorID).UseIdentityColumn();
            builder.Property(x => x.EditorID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);
        }
    }
}
