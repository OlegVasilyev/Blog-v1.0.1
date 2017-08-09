using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayerInterfaces.Repository;
using System.Data.Entity;

namespace DataAccessLayerSQL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public void Create(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var item = context.Set<T>().Find(Id);
            if (item != null)
                context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public T Get(int Id)
        {
            return context.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}