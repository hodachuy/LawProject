using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("PostTags");
            builder.HasKey(x => new { x.PostID, x.TagID });
            builder.HasOne<Post>(ad => ad.Post)
                   .WithMany(x => x.PostTags)
                   .HasForeignKey(ad => ad.PostID);
        }
    }
}
