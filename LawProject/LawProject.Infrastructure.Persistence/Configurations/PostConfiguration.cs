using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.PostID);
            builder.Property(x => x.PostID).UseIdentityColumn();
            builder.Property(x => x.PostID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(350);
            builder.Property(x => x.Alias).IsRequired().HasColumnType("varchar").HasMaxLength(350);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.IsDelete).HasDefaultValue(false);
            builder.Property(x => x.IsPublish).HasDefaultValue(false);
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.Description).HasMaxLength(550);

            builder.HasOne<PostCategory>(ad => ad.PostCategory)
                .WithMany(x => x.Posts)
                .HasForeignKey(ad => ad.PostCategoryID);

            builder.HasMany<PostTag>(ad => ad.PostTags)
                .WithOne(x => x.Post)
                .HasForeignKey(ad => ad.PostID);
        }
    }
}
