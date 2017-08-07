using Entities.Models;
using System.Data.Entity;

namespace DataAccessLayerInterfaces.Interfaces
{
    public interface IContext
    {
          DbSet<Quiz> Quizes { get; set; }
          DbSet<Article> Articles { get; set; }
          DbSet<Answer> Answers { get; set; }
          DbSet<Review> Reviews { get; set; }
          DbSet<Tagg> Tags { get; set; }
    }
}
