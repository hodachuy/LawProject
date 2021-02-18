using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsPublished).HasDefaultValue(false);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);

            builder.HasMany<District>(ad => ad.Districts)
                .WithOne(x => x.Province)
                .HasForeignKey(ad => ad.ProvinceID);
        }
    }
}
