using DataAccessLayerInterfaces.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayerSQL.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly DbContext context;
        public CommentRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(Comment item)
        {
            context.Set<Comment>().Add(item);
        }

        public void Delete(int Id)
        {
            var tag = context.Set<Comment>().Find(Id);
            context.Set<Comment>().Remove(tag);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return context.Set<Comment>().Where(predicate).ToList();
        }

        public Comment Get(int Id)
        {
            return context.Set<Comment>().Find(Id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return context.Set<Comment>();
        }

        public void Update(Comment item)
        {
            var temp = context.Set<Comment>().Find(item.Id);
            if (temp != null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}