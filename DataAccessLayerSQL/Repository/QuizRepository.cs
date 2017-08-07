using DataAccessLayerInterfaces.Repository;
using DataAccessLayerSQL.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayerSQL.Repositories
{
    public class QuizRepository : IRepository<Quiz>
    {
        readonly private DbContext context;
        public QuizRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(Quiz item)
        {
            context.Set<Quiz>().Add(item);
        }

        public void Delete(int Id)
        {
            var user = context.Set<Quiz>().Find(Id);
            context.Set<Quiz>().Remove(user);
        }

        public IEnumerable<Quiz> Find(Func<Quiz, bool> predicate)
        {
            return context.Set<Quiz>().Where(predicate).ToList();
        }

        public Quiz Get(int Id)
        {
            return context.Set<Quiz>().Find(Id);
        }

        public IEnumerable<Quiz> GetAll()
        {
            return context.Set<Quiz>();
        }

        public void Update(Quiz item)
        {
            var user = context.Set<Quiz>().Find(item.Id);
            if(user !=null)
            {
                context.Entry(user).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}