using DataAccessLayerSQL.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayerInterfaces.Repository;
using System.Data.Entity;

namespace DataAccessLayerSQL.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private readonly DbContext context;
        public AnswerRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(Answer item)
        {
            context.Set<Answer>().Add(item);
        }

        public void Delete(int Id)
        {
            var answer = context.Set<Answer>().Find(Id);
            if (answer != null)
                context.Set<Answer>().Remove(answer);
        }

        public IEnumerable<Answer> Find(Func<Answer, bool> predicate)
        {
            return context.Set<Answer>().Where(predicate).ToList();
        }

        public Answer Get(int Id)
        {
            return context.Set<Answer>().Find(Id);
        }

        public IEnumerable<Answer> GetAll()
        {
            return context.Set<Answer>();
        }

        public void Update(Answer item)
        {
            var temp = context.Set<Answer>().Find(item.Id);
            if(temp != null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}