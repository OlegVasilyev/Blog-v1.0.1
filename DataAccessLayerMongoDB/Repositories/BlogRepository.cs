using System;
using Entities.Models;
using DataAccessLayerMongoDB.Context;
using DataAccessLayerInterfaces.Repository;

namespace DataAccessLayerMongoDB.Repositories
{
    public class BlogRepositories : IBlogRepository
    {
        private readonly MongoDataConetext _context;
        private Repository<Article> articleRepository;
        private Repository<Quiz> quizRepository;
        private Repository<Tagg> tagRepository;
        private Repository<Review> reviewrepRepository;
        private Repository<Comment> commentRepository;
        private Repository<Question> questionRepository;
        private Repository<Answer> answerRepository;
        public BlogRepositories() { }
        public IRepository<Article> Articles => articleRepository ?? (articleRepository = new Repository<Article>(_context));

        public IRepository<Review> Reviews => reviewrepRepository ?? (reviewrepRepository = new Repository<Review>(_context));
        public IRepository<Answer> Answers => answerRepository ?? (answerRepository = new Repository<Answer>(_context));
        public IRepository<Quiz> Quizes => quizRepository ?? (quizRepository = new Repository<Quiz>(_context));
        public IRepository<Tagg> Tags => tagRepository ?? (tagRepository = new Repository<Tagg>(_context));
        public IRepository<Question> Questions => questionRepository ?? (questionRepository = new Repository<Question>(_context));
        private bool disposed;
        public IRepository<Comment> Comments => commentRepository ?? (commentRepository = new Repository<Comment>(_context));

       
        public virtual void Dispose(bool disposing)
        {
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        public void Save()
        {
        }
    }
}
