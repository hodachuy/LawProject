using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class QuestionCommentConfiguration : IEntityTypeConfiguration<QuestionComment>
    {
        public void Configure(EntityTypeBuilder<QuestionComment> builder)
        {
            builder.ToTable("QuestionComments");
            builder.HasKey(x => x.CommentID);
            builder.Property(x => x.CommentID).UseIdentityColumn();
            builder.Property(x => x.CommentID).IsRequired();
            builder.Property(x => x.AccountID).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.QuesID).IsRequired();
            builder.Property(x => x.VoteLike).HasDefaultValue(0);
            builder.Property(x => x.IsSolution).HasDefaultValue(false);
            builder.Property(x => x.FlaggedAsSpam).HasDefaultValue(false);
            builder.Property(x => x.Pending).HasDefaultValue(false);

            builder.HasOne<Question>(ad => ad.Question)
                .WithMany(x => x.QuestionComments)
                .HasForeignKey(ad => ad.QuesID);
        }
    }
}
