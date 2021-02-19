using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using LawProject.Domain.Enum;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.StatusValue).IsRequired().HasDefaultValue(Status.Notify.SHOW_NOT_READ);
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
