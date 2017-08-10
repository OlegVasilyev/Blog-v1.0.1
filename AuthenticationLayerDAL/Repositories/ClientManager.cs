using AuthenticationLayerDAL.Context;
using AuthenticationLayerDAL.Interface.Interfaces;
using Entities.IdentityEnties;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthenticationLayerDAL.Repositories
{
    class ClientManager : IClientManager
    {
        public IdentityDbContext<ApplicationUser> _database;

        public ClientManager(IdentityDbContext<ApplicationUser> db)
        {
            _database = db;
        }

        public void Create(ClientProfile item)
        {
            _database.Set<ClientProfile>().Add(item);
            _database.SaveChanges();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
