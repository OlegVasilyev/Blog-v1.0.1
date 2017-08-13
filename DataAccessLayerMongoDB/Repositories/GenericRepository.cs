using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using Entities.Models;
using DataAccessLayerMongoDB.Context;
using DataAccessLayerInterfaces.Repository;

namespace DataAccessLayerMongoDB.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MongoDataConetext blogContext;
        public Repository(MongoDataConetext  blogContext = null)
        {
            this.blogContext = blogContext !=null ? blogContext : new MongoDataConetext();
        }

        public TEntity Get(string Id)
        {
            BsonDocument filter = new BsonDocument("Id", Id);
            return blogContext.GetCollection<TEntity>().Find<TEntity>(filter).First();
        }

        public void Create(TEntity item)
        {
            blogContext.GetCollection<TEntity>().InsertOne(item);
        }
        public void Delete(string Id)
        {
            blogContext.GetCollection<TEntity>().DeleteOne(Builders<TEntity>.Filter.Eq("Id", Id));
        }
        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return blogContext.GetCollection<TEntity>().Find<TEntity>(predicate.ToBsonDocument()).ToList();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return blogContext.GetCollection<TEntity>().Find<TEntity>(new BsonDocument()).ToList();
        }
        public void Update(TEntity item)
        {
           //blogContext.GetCollection<TEntity>().ReplaceOne(doc => doc.Id == item.Id, item);
        }
    }
}