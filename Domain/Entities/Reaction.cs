using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reaction: Entity
    {
        public string Name { get; set; }
        //public string EmojiIconPath { get; set; }

        public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
        public virtual ICollection<CommentReaction> CommentReactions { get; set; } = new List<CommentReaction>();


    }
}
