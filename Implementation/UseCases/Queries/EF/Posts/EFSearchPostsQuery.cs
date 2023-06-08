using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
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
    public class EFSearchPostsQuery : EFUseCase, ISearchPostsQuery
    {
        public EFSearchPostsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Search Posts";

        public string Description => "Searching posts by keyword using Entity Framework";

        public IEnumerable<PostListDto> Execute(SearchDto request)
        {
            var postsQuery = Context.Posts.Include(x => x.PostReactions).ThenInclude(x => x.Reaction)
                                          .Include(x => x.Comments).ThenInclude(x => x.Author)
                                          .Include(x => x.Author)
                                          .Include(x => x.PostTags).ThenInclude(x => x.Tag)
                                          .Where(x=> x.Active == true)
                                          .AsQueryable();

            if (!string.IsNullOrEmpty(request.keyword))
            {
                postsQuery = postsQuery.Where(x => x.Title.Contains(request.keyword)
                                                || x.Author.FirstName.Contains(request.keyword)
                                                || x.Author.LastName.Contains(request.keyword)
                                                || x.PostTags.Any(x => x.Tag.Name.Contains(request.keyword)));
            }

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
