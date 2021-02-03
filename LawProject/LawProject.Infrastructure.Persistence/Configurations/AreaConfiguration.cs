using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Areas");
            builder.HasKey(x => x.AreaID);
            builder.Property(x => x.AreaID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);
        }
    }
}
