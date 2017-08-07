using DataAccessLayerInterfaces.Interfaces;
using DataAccessLayerInterfaces.Repository;
using DataAccessLayerSQL.Context;
using Entities.Models;
using System;
using System.Data.Entity;

namespace DataAccessLayerSQL.Repositories
{
    public class BlogRepositories : IBlogRepository
    {
        private readonly DbContext _context;
        private ArticleRepository articleRepository;
        private AnswerRepository answerRepository;
        private QuizRepository quizRepository;
        private TagRepository tagRepository;
        private ReviewRepository reviewrepRepository;
        private CommentRepository commentRepository;

        public BlogRepositories(DbContext context)
        {
            _context = context;
        }
        public IRepository<Article> Articles => articleRepository ?? (articleRepository = new ArticleRepository(_context));

        public IRepository<Review> Reviews => reviewrepRepository ?? (reviewrepRepository = new ReviewRepository(_context));

        public IRepository<Quiz> Quizes => quizRepository ?? (quizRepository = new QuizRepository(_context));
        public IRepository<Comment> Comments => commentRepository ?? (commentRepository = new CommentRepository(_context));

        public IRepository<Answer> Answers => answerRepository ?? (answerRepository = new AnswerRepository(_context));

        public IRepository<Tagg> Tags => tagRepository ?? (tagRepository = new TagRepository(_context));
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