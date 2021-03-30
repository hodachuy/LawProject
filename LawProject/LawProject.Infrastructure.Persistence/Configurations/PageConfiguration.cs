using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages");
            builder.HasKey(x => x.PageID);
            builder.Property(x => x.PageID).UseIdentityColumn();
            builder.Property(x => x.PageID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(350);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(350);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsActive).HasDefaultValue(false);
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
