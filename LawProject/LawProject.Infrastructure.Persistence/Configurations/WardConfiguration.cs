using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class WardConfiguration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.ToTable("Wards");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.DistrictID).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsPublished).HasDefaultValue(false);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);

            builder.HasOne<District>(ad => ad.District)
                .WithMany(x => x.Wards)
                .HasForeignKey(ad => ad.DistrictID);
        }
    }
}
