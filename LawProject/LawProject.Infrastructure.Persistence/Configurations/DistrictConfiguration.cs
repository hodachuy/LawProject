using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ProvinceID).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsPublished).HasDefaultValue(false);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);

            builder.HasOne<Province>(ad => ad.Province)
                .WithMany(x => x.Districts)
                .HasForeignKey(ad => ad.ProvinceID);

            builder.HasMany<Ward>(ad => ad.Wards)
                .WithOne(x => x.District)
                .HasForeignKey(ad => ad.DistrictID);
        }
    }
}
