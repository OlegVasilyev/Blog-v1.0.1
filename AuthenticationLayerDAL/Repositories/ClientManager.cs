using AuthenticationLayerDAL.Context;
using AuthenticationLayerDAL.Interface.Interfaces;
using Entities.IdentityEnties;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthenticationLayerDAL.Repositories
{
    class ClientManager : IClientManager
    {
        public IdentityDbContext Database { get; set; }

        public ClientManager(IdentityDbContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.Set<ClientProfile>().Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
