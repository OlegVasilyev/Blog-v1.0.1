using System;
using Entities.IdentityEnties;
using AuthenticationLayer.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AuthenticationLayerDAL.Interface.Interfaces;

namespace AuthenticationLayerDAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IdentityDbContext _db;

        public AuthenticationRepository(IdentityDbContext context)
        {
            _db = context;
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            ClientManager = new ClientManager(_db);
        }

        public virtual ApplicationUserManager UserManager { get; }

        public virtual IClientManager ClientManager { get; }

        public virtual ApplicationRoleManager RoleManager { get; }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            //All unmanaged resources was disposed so GC needn't to call finalize method
            GC.SuppressFinalize(this);
        }
        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Frees resources
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ClientManager.Dispose();
                }
                _disposed = true;
            }
        }
    }
}