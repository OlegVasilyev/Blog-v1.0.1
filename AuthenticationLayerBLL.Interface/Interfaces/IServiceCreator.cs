using AuthenticationLayerBLL.Interface.Interfaces;
using Entities.IdentityEnties;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthenticationLayerBLL.Interfaces
{
    /// <summary>
    /// Using for realisation of abstract factory pattern
    /// </summary>
    public interface IServiceCreator
    {
        /// <summary>
        /// Creates an instance of IUserService
        /// </summary>
        /// <param name="connection">DbContext</param>
        /// <returns>Instance of implementation of IUserService interface</returns>
        IUserService CreateUserService();
    }

}
