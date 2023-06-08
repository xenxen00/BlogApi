using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.EF.Posts
{
    public class EFGetPostDetailsQuery : EFUseCase, IGetPostDetailsQuery
    {
        public EFGetPostDetailsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Get post details (EF)";

        public string Description => "Get post details using Entity Framework";

        public PostDto Execute(int request)
        {
            var post = Context.Posts.Include(x => x.PostReactions).ThenInclude(x => x.Reaction)
                                          .Include(x => x.Comments).ThenInclude(x => x.Author)
                                          .Include(x => x.Author)
                                          .Include(x => x.PostTags).ThenInclude(x => x.Tag)
                                          .Where(x => x.Id == request && x.Active == true).FirstOrDefault();
            return new PostDto
            {
                Title = post.Title,
                Content = post.Content,
                Author = post.Author.FirstName + ' ' + post.Author.LastName,
                Category = post.Category.Name,
                PostedAt = post.CreatedAt,
                LastEditedAt = post.UpdatedAt,
                Comments = post.Comments.Select(x => new Comment
                {
                    Content = post.Content,
                    CommentedAt = post.CreatedAt,
                    PostedBy = post.Author.FirstName + ' ' + post.Author.LastName
                }),
                Tags = post.PostTags.Select(x => x.Tag.Name).ToArray(),
                PostReactions = new PostReaction
                {
                    NumberOfReactions = post.PostReactions.Count,
                    Reactions = post.PostReactions.Select(x => new Reaction
                    {
                        Name = x.Reaction.Name,
                        ReactedBy = x.User.FirstName + ' ' + x.User.LastName
                    })
                }
            };
        }
    }
}
