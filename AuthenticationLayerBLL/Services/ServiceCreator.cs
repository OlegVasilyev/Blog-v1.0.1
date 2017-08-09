using AuthenticationLayerBLL.Interface.Interfaces;
using AuthenticationLayerBLL.Interfaces;
using AuthenticationLayerDAL.Context;
using AuthenticationLayerDAL.Repositories;
using Entities.IdentityEnties;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthenticationLayerBLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService()
        {
            return new UserService(new AuthenticationRepository(new IdentityDbContext()));
        }
    }
}
