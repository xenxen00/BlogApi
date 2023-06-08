using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
        public virtual ICollection<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<CommentReaction> CommentReactions { get; set; } = new List<CommentReaction>();

    }
}
