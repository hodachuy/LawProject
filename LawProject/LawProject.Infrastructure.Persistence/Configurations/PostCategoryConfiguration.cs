using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("PostCategories");
            builder.HasKey(x => x.PostCategoryID);
            builder.Property(x => x.PostCategoryID).UseIdentityColumn();
            builder.Property(x => x.PostCategoryID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Alias).IsRequired().HasColumnType("varchar").HasMaxLength(250);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.Description).HasMaxLength(550);

            builder.HasMany<Post>(ad => ad.Posts)
                .WithOne(x => x.PostCategory)
                .HasForeignKey(ad => ad.PostCategoryID);
        }
    }
}
