using Application.UseCases.DTO;
using Application.UseCases.Queries.SavedPosts;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.EF
{
    public class EFGetSavedPostsQuery : EFUseCase, IGetSavedPostsQuery
    {
        private readonly IApplicationUser _user;

        public EFGetSavedPostsQuery(BlogContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 33;

        public string Name => "";

        public string Description => "";

        public IEnumerable<PostListDto> Execute()
        {
            var postsQuery = Context.Posts.Include(x => x.PostReactions).ThenInclude(x => x.Reaction)
                                          .Include(x => x.Comments).ThenInclude(x => x.Author)
                                          .Include(x => x.Author)
                                          .Where(x => x.ReadingLists.Any(y => y.PostId == x.Id && y.UserId == _user.Id))
                                          .AsQueryable();

            var data = postsQuery.Select(x => new PostListDto
            {
                Title = x.Title,
                Content = x.Content,
                Author = x.Author.FirstName + ' ' + x.Author.LastName,
                Category = x.Category.Name,
                PostedAt = x.CreatedAt,
                LastEditedAt = x.UpdatedAt,
                NumberOfComments = x.Comments.Count(),
                NumberOfPostReactions = x.PostReactions.Count()
            }).ToList();

            return data;
      
        }
    }
}
