using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.ArticleID);
            builder.Property(x => x.ArticleID).UseIdentityColumn();
            builder.Property(x => x.ItemID).IsRequired();
            builder.Property(x => x.LegalID).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Idx).HasDefaultValue(0);
        }
    }
}
