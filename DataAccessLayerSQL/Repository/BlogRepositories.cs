using DataAccessLayerInterfaces.Repository;
using Entities.Models;
using System;
using System.Data.Entity;

namespace DataAccessLayerSQL.Repositories
{
    public class BlogRepositories : IBlogRepository
    {
        private readonly DbContext _context;
        private Repository<Article> articleRepository;
        private Repository<Answer> answerRepository;
        private Repository<Quiz> quizRepository;
        private Repository<Tagg> tagRepository;
        private Repository<Review> reviewrepRepository;
        private Repository<Comment> commentRepository;

        public BlogRepositories(DbContext context)
        {
            _context = context;
        }
        public IRepository<Article> Articles => articleRepository ?? (articleRepository = new Repository<Article>(_context));

        public IRepository<Review> Reviews => reviewrepRepository ?? (reviewrepRepository = new Repository<Review>(_context));

        public IRepository<Quiz> Quizes => quizRepository ?? (quizRepository = new Repository<Quiz>(_context));
        public IRepository<Comment> Comments => commentRepository ?? (commentRepository = new Repository<Comment>(_context));

        public IRepository<Answer> Answers => answerRepository ?? (answerRepository = new Repository<Answer>(_context));

        public IRepository<Tagg> Tags => tagRepository ?? (tagRepository = new Repository<Tagg>(_context));
        private bool disposed;
        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}