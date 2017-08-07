using System.Data.Entity;
using Entities.Models;
using DataAccessLayerInterfaces.Interfaces;

namespace DataAccessLayerSQL.Context
{
    /// <summary>
    /// Context for working with related database
    /// </summary>
    public class BlogContext : DbContext, IContext
    {
        public BlogContext() : base("name=BlogContext") { }
        public virtual DbSet<Quiz> Quizes { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Tagg> Tags { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        /// <summary>
        /// Static constructor for setting DB initializer
        /// </summary>
        static BlogContext()
        {
            Database.SetInitializer(new BlogInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany(c => c.Tags)
                .WithMany(s => s.Articles)
                .Map(t => t.MapLeftKey("ArticleId")
                .MapRightKey("TagId")
                .ToTable("ArticleTag"));
        }
    }

}