using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");
            builder.HasKey(x => x.ActivityID);
            builder.Property(x => x.ActivityID).UseIdentityColumn();
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Timestamp).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
