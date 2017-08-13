using System.Configuration;
using MongoDB.Driver;
using Entities.Models;

namespace DataAccessLayerMongoDB.Context
{
    public class MongoDataConetext
    {
        public const string connectionName = "Blog";
        public const string databaseName = "EpamBlog";

        private static readonly IMongoClient client;
        private static readonly IMongoDatabase database;

        static MongoDataConetext()
        {
            var connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }
        /// <summary>
        /// The private GetCollection method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
        }
    }
}