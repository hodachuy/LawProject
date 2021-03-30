using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class LawyerConfiguration : IEntityTypeConfiguration<Lawyer>
    {
        public void Configure(EntityTypeBuilder<Lawyer> builder)
        {
            builder.ToTable("Lawyers");
            builder.HasKey(x => x.LawyerID);
            builder.Property(x => x.LawyerID).UseIdentityColumn();
            builder.Property(x => x.LawyerID).IsRequired();
            builder.Property(x => x.AccountID).IsRequired();
            builder.Property(x => x.SocialNetwork).IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.IsPublished).HasDefaultValue(false);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(350);
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.Website).IsUnicode(false);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);
        }
    }
}
