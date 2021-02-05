﻿using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class LegalDocumentConfiguration : IEntityTypeConfiguration<LegalDocument>
    {
        public void Configure(EntityTypeBuilder<LegalDocument> builder)
        {
            builder.ToTable("LegalDocuments");
            builder.HasKey(x => x.LegalID);
            builder.Property(x => x.LegalID).UseIdentityColumn();
            builder.Property(x => x.LegalID).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.IsDelete).HasDefaultValue(false);
            builder.Property(x => x.IsPublish).HasDefaultValue(false);
            builder.Property(x => x.IsTraining).HasDefaultValue(false);
            builder.Property(x => x.LegalGroupID).IsRequired();
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.IsHasAppendix).HasDefaultValue(false);
            builder.Property(x => x.StatusValue).IsRequired();
        }
    }
}
