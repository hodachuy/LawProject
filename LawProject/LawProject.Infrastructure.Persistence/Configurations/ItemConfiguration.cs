using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(x => x.ItemID);
            builder.Property(x => x.ItemID).UseIdentityColumn();
            builder.Property(x => x.ItemID).IsRequired();
            builder.Property(x => x.Idx).HasDefaultValue(0);
        }
    }
}
