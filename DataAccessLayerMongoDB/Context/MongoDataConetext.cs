using System.Configuration;
using MongoDB.Driver;
using Entities.Models;

namespace DataAccessLayerMongoDB.Context
{
    public class MongoDataConetext
    {
        public const string CONNECTION_STRING_NAME = "Blog";
        public const string DATABASE_NAME = "blog";

        private static readonly IMongoClient client;
        private static readonly IMongoDatabase database;

        static MongoDataConetext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            client = new MongoClient(connectionString);
            database = client.GetDatabase(DATABASE_NAME);
        }
        public IMongoClient Client
        {
            get { return client; }
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