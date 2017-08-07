using DataAccessLayerInterfaces.Repository;
using DataAccessLayerSQL.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayerSQL.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        readonly private DbContext context;
        public ReviewRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(Review item)
        {
            context.Set<Review>().Add(item);
        }
        public void Delete(int Id)
        {
            var review = context.Set<Review>().Find(Id);
            context.Set<Review>().Remove(review);
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return context.Set<Review>().Where(predicate).ToList();
        }

        public Review Get(int Id)
        {
            return context.Set<Review>().Find(Id);
        }

        public IEnumerable<Review> GetAll()
        {
            return context.Set<Review>();
        }

        public void Update(Review item)
        {
            var review = context.Set<Review>().Find(item.Id);
            if(review != null)
            {
                context.Entry(review).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}