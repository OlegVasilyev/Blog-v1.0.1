using AuthenticationLayer.BLL.Interfaces;
using AuthenticationLayer.DAL.Repositories;

namespace AuthenticationLayer.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityBlogAuth(connection));
        }
    }
}
