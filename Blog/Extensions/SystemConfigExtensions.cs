using Api.Core;
using Application.UseCases.Commands;
using Application;
using Implementation.UseCases.Commands.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using DataAccess;
using Implementation.Validators;
using Application.UseCases.Queries;
using Implementation.UseCases.Queries.EF.Posts;
using Application.UseCases.Commands.Posts;
using Implementation.UseCases.Commands.EF.Posts;
using Application.UseCases.Queries.Roles;
using Implementation.UseCases.Queries.EF.Roles;
using Application.UseCases.Commands.Roles;
using Implementation.UseCases.Commands.EF.Role;
using Implementation.UseCases.Commands.EF.Reactions;
using Implementation.UseCases.Commands.EF.Roles;
using Application.UseCases.Commands.Permissions;
using Implementation.UseCases.Commands.EF.Permissions;
using Application.UseCases.Queries.Permissions;
using Implementation.UseCases.Queries.EF.Permissions;
using Application.UseCases.Queries.Categories;
using Implementation.UseCases.Queries.EF.Categories;
using Application.UseCases.Commands.Categories;
using Implementation.UseCases.Commands.EF.Categories;
using Implementation.UseCases.Queries.EF.Reactions;
using Application.UseCases.Commands.Reaction;
using Application.UseCases.Queries.SavedPosts;
using Implementation.UseCases.Commands.EF.SavedPosts;
using Implementation.UseCases.Queries.EF;
using Application.UseCases.Commands.SavedPosts;
using Application.UseCases.Commands.Comments;
using Implementation.UseCases.Commands.EF.Comments;
using Application.UseCases.Commands.Images;
using Implementation.UseCases.Commands.EF.Images;
using Application.UseCases.Commands.Users;
using Implementation.UseCases.Commands.EF.Users;
using Application.UseCases.Commands.PostReactions;
using Implementation.UseCases.Commands.EF.PostReactions;
using Application.UseCases.Queries.Tags;
using Implementation.UseCases.Queries.EF.Tags;
using Application.UseCases.Commands.Tag;
using Implementation.UseCases.Commands.EF.Tags;

namespace Api.Extensions
{
    public static class SystemConfigExtensions
    {
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<BlogContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            #region services
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
            //Posts
            services.AddTransient<IGetPostDetailsQuery, EFGetPostDetailsQuery>();
            services.AddTransient<ISearchPostsQuery, EFSearchPostsQuery>();
            services.AddTransient<IUpdatePostCommand, EFUpdatePostCommand>();
            services.AddTransient<ICreatePostCommand, EFCreatePostCommand>();
            //Roles
            services.AddTransient<IGetRolesQuery, EFGetRolesQuery>();
            services.AddTransient<ICreateRoleCommand, EFCreateRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, EFUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            //Permissions
            services.AddTransient<ICreatePermissionCommand, EFCreatePermissionCommand>();
            services.AddTransient<IUpdatePermissionCommand, EFUpdatePermissionCommand>();
            services.AddTransient<IDeletePermissionCommand, EFDeletePermissionCommand>();
            services.AddTransient<IGetPermissionsQuery, EFGetPermissionsQuery>();
            //Categories
            services.AddTransient<IGetCategoriesQuery, EFGetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EFUpdateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();
            //Reactions
            services.AddTransient<IGetReactionsQuery, EFGetReactionsQuery>();
            services.AddTransient<ICreateReactionCommand, EFCreateReactionCommand>();
            services.AddTransient<IUpdateReactionCommand, EFUpdateReactionCommand>();
            services.AddTransient<IDeleteReactionCommand, EFDeleteReactionCommand>();
            //Saved posts
            services.AddTransient<IGetSavedPostsQuery, EFGetSavedPostsQuery>();
            services.AddTransient<ISavePostCommand, EFSavePostCommand>();
            services.AddTransient<IDeletePostCommand, EFDeletePostCommand>();
            services.AddTransient<IRemovePostFromSavedCommand, EFRemovePostFromSaved>();
            //Tags
            services.AddTransient<IGetTagsQuery, EFGetTagsQuery>();
            services.AddTransient<ICreateTagCommand, EFCreateTagCommand>();
            services.AddTransient<IDeleteTagCommand, EFDeleteTagCommand>();
            services.AddTransient<IUpdateTagCommand, EFUpdateTagCommand>();
            //Comments
            services.AddTransient<IDeleteCommentCommand, EFDeleteCommentCommand>();
            services.AddTransient<ICreateCommentCommand, EFCreateCommentCommand>();
            services.AddTransient<IUpdateCommentCommand, EFUpdateCommentCommand>();
            //Images
            services.AddTransient<IDeleteImageCommand, EFDeleteImageCommand>();
            //Users
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            //RolePermissions
            services.AddTransient<IAddPermissionToRole, EFAddPermissionToRoleCommand>();
            services.AddTransient<IDeleteRolePermission, EFDeleteRolePermission>();
            //PostReactions
            services.AddTransient<IDeletePostReactionCommand, EFDeletePostReaction>();
            services.AddTransient<ICreatePostReaction, EFPostReactionCreateCommand>();
            #endregion

            #region Validators
            services.AddTransient<RegistrationValidator>();
            services.AddTransient<LoginValidator>();
            services.AddTransient<TagValidator>();
            services.AddTransient<CategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<UpdateCommentValidator>();
            services.AddTransient<PermissionValidator>();
            services.AddTransient<PostValidator>();
            services.AddTransient<ImageValdiator>();
            services.AddTransient<RoleValidator>();
            services.AddTransient<ReactionValidator>();
            services.AddTransient<UpdateRoleValidator>();
            services.AddTransient<UpdatePostValidator>();
            services.AddTransient<UpdatePermissionValidator>();
            services.AddTransient<UpdateReactionValidator>();
            services.AddTransient<UpdateTagValidator>();

            #endregion
        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new UnauthorizedUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    PermissionsIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }

        public static void AddBlogContext(this IServiceCollection services)
        {
           services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = x.GetService<AppSettings>().ConnString;

                optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new BlogContext(options, x.GetService<IHttpContextAccessor>());
            });
            
        }

    }
}
