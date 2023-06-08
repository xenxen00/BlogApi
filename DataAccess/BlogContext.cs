using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess
{
    public class BlogContext : DbContext
    {

        //public BlogContext(DbContextOptions options) : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        protected IApplicationUser User { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });
            modelBuilder.Entity<SavedPost>().HasKey(x => new { x.PostId, x.UserId });
            modelBuilder.Entity<PostReaction>().HasKey(x => new { x.PostId, x.UserId, x.ReactionId });
            modelBuilder.Entity<CommentReaction>().HasKey(x => new { x.CommentId, x.UserId, x.ReactionId });
            modelBuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionId });           

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach(var entry in this.ChangeTracker.Entries())
            {
                if(entry.Entity is Entity entity)
                {
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            entity.Active = true;
                            entity.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedAt = DateTime.UtcNow;
                            entity.UpdatedBy = User.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-27P65MU\\sqlexpress;Initial Catalog=Blog;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Post>  Posts {get; set;}
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<Domain.Entities.Image> Images { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolesPermissions { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }


    }
}