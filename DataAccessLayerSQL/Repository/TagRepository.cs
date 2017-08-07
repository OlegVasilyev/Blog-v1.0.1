using DataAccessLayerInterfaces.Repository;
using DataAccessLayerSQL.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayerSQL.Repositories
{
    public class TagRepository : IRepository<Tagg>
    {
        private readonly DbContext context;
        public TagRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(Tagg item)
        {
            context.Set<Tagg>().Add(item);
        }

        public void Delete(int Id)
        {
            var tag = context.Set<Tagg>().Find(Id);
            context.Set<Tagg>().Remove(tag);
        }

        public IEnumerable<Tagg> Find(Func<Tagg, bool> predicate)
        {
            return context.Set<Tagg>().Where(predicate).ToList();
        }

        public Tagg Get(int Id)
        {
            return context.Set<Tagg>().Find(Id);
        }

        public IEnumerable<Tagg> GetAll()
        {
            return context.Set<Tagg>();
        }

        public void Update(Tagg item)
        {
            var temp = context.Set<Tagg>().Find(item.Id);
            if(temp!=null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}