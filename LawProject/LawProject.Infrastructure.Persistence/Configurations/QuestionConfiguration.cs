using LawProject.Domain.Entities;
using LawProject.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(x => x.QuesID);
            builder.Property(x => x.QuesID).UseIdentityColumn();
            builder.Property(x => x.QuesID).IsRequired();
            builder.Property(x => x.AccountID).IsRequired();
            builder.Property(x => x.QuesCode).IsRequired();
            builder.Property(x => x.QuesContent).IsRequired();
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.StatusValue).HasDefaultValue(Status.QuestionAnswer.NoAnswer);

            builder.HasOne<Answer>(ad => ad.Answer)
                .WithOne(x => x.Question)
                .HasForeignKey<Answer>(ad => ad.QuesID);

            builder.HasMany<QuestionComment>(ad => ad.QuestionComments)
                .WithOne(x => x.Question)
                .HasForeignKey(ad => ad.QuesID);
        }
    }
}
