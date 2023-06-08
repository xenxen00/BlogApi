using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class PostReactionDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int ReactionId { get; set; }
    }
}
