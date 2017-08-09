using DataAccessLayerInterfaces.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayerSQL.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly DbContext context;
        public ArticleRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(Article item)
        {
            context.Set<Article>().Add(item);
        }

        public void Delete(int Id)
        {
            var article = context.Set<Article>().Find(Id);
            if (article != null)
                context.Set<Article>().Remove(article);
        }

        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return context.Set<Article>().Where(predicate).ToList();
        }

        public Article Get(int Id)
        {
            return context.Set<Article>().Find(Id);
        }

        public IEnumerable<Article> GetAll()
        {
            return context.Set<Article>();
        }

        public void Update(Article item)
        {
            var temp = context.Set<Article>().Find(item.Id);
            if(temp != null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}