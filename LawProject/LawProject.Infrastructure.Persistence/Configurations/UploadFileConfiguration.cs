using LawProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Configurations
{
    public class UploadFileConfiguration : IEntityTypeConfiguration<UploadFile>
    {
        public void Configure(EntityTypeBuilder<UploadFile> builder)
        {
            builder.ToTable("UploadFiles");
            builder.HasKey(x => x.FileID);
            builder.Property(x => x.FileID).UseIdentityColumn();
            builder.Property(x => x.FileID).IsRequired();
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
