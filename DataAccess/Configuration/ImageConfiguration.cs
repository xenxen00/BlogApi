using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(200);

            builder.HasOne(x => x.Post).WithMany(x => x.Images).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
