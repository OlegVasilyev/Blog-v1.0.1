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
        public Repository()
        {
                
        }
        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}