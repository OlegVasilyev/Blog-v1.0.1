using Entities.Models;
using System;

namespace DataAccessLayerInterfaces.Repository
{

    public interface IBlogRepository : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Question> Questions { get; }
        IRepository<Quiz> Quizes {get;}
        IRepository<Comment> Comments {get; }
        IRepository<Answer> Answers { get; }
        IRepository<Tagg> Tags { get; }
        void Save();
    }
}