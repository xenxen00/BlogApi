using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public abstract class BaseCommentDto
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
        public int? ParentCommentId { get; set; }
    }

    public class CreateCommentDto: BaseCommentDto
    {
    }

    public class UpdateCommentDto : BaseCommentDto
    {
        public int Id { get; set; }
    }

}
