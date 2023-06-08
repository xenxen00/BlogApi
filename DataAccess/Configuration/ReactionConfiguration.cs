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
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            builder.HasMany(x => x.PostReactions).WithOne(x => x.Reaction).HasForeignKey(x => x.ReactionId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
