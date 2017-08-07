using System;
using Microsoft.AspNet.Identity.EntityFramework;
using AuthenticationLayer.DAL.Interfaces;
using AuthenticationLayer.DAL.Context;
using Entities.IdentityEnties;
using AuthenticationLayer.DAL.Identity;
using AuthenticationLayer.DAL.Repositories;

namespace AuthenticationLayer.DAL.Repositories
{
    public class IdentityBlogAuth : IBlogAuth
    {
        private readonly AuthenticationContext _db;

        public IdentityBlogAuth(string connectionString)
        {
            _db = new AuthenticationContext(connectionString);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            ClientManager = new ClientManager(_db);
        }

        public ApplicationUserManager UserManager { get; }

        public IClientManager ClientManager { get; }

        public ApplicationRoleManager RoleManager { get; }

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