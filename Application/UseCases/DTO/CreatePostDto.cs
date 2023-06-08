using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public abstract class BasePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
    }

    public class ImageDto
    {
        public string Path { get; set; }
    }

    public class CreatePostDto: BasePostDto
    {

    }

    public class UpdatePostDto: BasePostDto
    {
        public int Id { get; set; }
    }


}
