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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Content).IsRequired().HasMaxLength(400);

            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Author).WithMany(x => x.Comments).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ParentComment).WithMany(x => x.ChildComments).HasForeignKey(x => x.ParentCommentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ChildComments).WithOne(x => x.ParentComment).HasForeignKey(x => x.ParentCommentId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
