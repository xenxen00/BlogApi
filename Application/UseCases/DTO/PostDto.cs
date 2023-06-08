using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime? LastEditedAt { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public PostReaction PostReactions { get; set; }
    }

    public class PostListDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime? LastEditedAt { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfPostReactions { get; set; }
    }

    public class Comment
    {
        public string Content { get; set; }
        public string PostedBy { get; set; }
        public DateTime CommentedAt { get; set; }
    }

    public class PostReaction
    {
        public int NumberOfReactions { get; set; }
        public IEnumerable<Reaction> Reactions { get; set; } 
    }

    public class Reaction
    {
        public string Name { get; set; }
        public string ReactedBy { get; set; }
    }



}
