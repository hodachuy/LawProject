using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class QuestionTagConfiguration : IEntityTypeConfiguration<QuestionTag>
    {
        public void Configure(EntityTypeBuilder<QuestionTag> builder)
        {
            builder.ToTable("QuestionTags");
            builder.HasKey(x => new { x.QuesID, x.TagID });

            builder.HasOne<Question>(ad => ad.Question)
                   .WithMany(x => x.QuestionTags)
                   .HasForeignKey(ad => ad.QuesID);
        }
    }
}
