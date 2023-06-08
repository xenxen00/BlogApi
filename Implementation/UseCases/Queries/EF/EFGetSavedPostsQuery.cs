using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.SavedPosts;
using DataAccess;
using Domain.Entities;
using Implementation.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public string Name => "Get saved posts";

        public string Description => "Get saved posts using EF";

        public PagedResponse<PostListDto> Execute(SearchDto request)
        {
            IQueryable<Post> postsQuery = Context.Posts.Include(x => x.PostReactions).ThenInclude(x => x.Reaction)
                                         .Include(x => x.Comments).ThenInclude(x => x.Author)
                                         .Include(x => x.Author)
                                         .Where(x => x.ReadingLists.Any(y => y.PostId == x.Id && y.UserId == _user.Id));

            if (!string.IsNullOrEmpty(request.keyword))
            {
                postsQuery = postsQuery.Where(x => x.Title.Contains(request.keyword)
                                                || x.Author.FirstName.Contains(request.keyword)
                                                || x.Author.LastName.Contains(request.keyword)
                                                || x.PostTags.Any(x => x.Tag.Name.Contains(request.keyword)));
            }

           var data = postsQuery.GetPagedResponse<Post, PostListDto>(request, x => new PostListDto
            {
                Title = x.Title,
                Content = x.Content,
                Author = x.Author.FirstName + ' ' + x.Author.LastName,
                Category = x.Category.Name,
                PostedAt = x.CreatedAt,
                LastEditedAt = x.UpdatedAt,
                NumberOfComments = x.Comments.Count(),
                NumberOfPostReactions = x.PostReactions.Count()
            });

            return data;
        }
    }
}
