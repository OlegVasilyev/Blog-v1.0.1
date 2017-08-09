using System;
using AuthenticationLayer.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AuthenticationLayerDAL.Interface.Interfaces;
using Entities.IdentityEnties;

namespace AuthenticationLayerDAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IdentityDbContext _db;
        private  IClientManager clientManager;
        private  ApplicationUserManager userManager;
        private  ApplicationRoleManager roleManager;
        public AuthenticationRepository(IdentityDbContext context)
        {
            _db = context;
        }

        public  IClientManager ClientManager => clientManager ?? (clientManager = new ClientManager(_db));

        public ApplicationRoleManager RoleManager => roleManager ?? (roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db)));
            public ApplicationUserManager UserManager => userManager ?? (userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db)));

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