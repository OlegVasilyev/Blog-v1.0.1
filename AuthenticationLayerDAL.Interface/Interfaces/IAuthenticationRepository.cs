using AuthenticationLayer.DAL.Identity;
using System;

namespace AuthenticationLayerDAL.Interface.Interfaces
{
    /// <summary>
    /// Interface for implementation of unit of work pattern.
    /// Presantation layer will work with Auth using this interface.
    /// Simply: unite all the implementations of generic repository together in one place.
    /// </summary>
    public interface IAuthenticationRepository : IDisposable
    {
        /// <summary>
        /// Access to class with user management
        /// </summary>
        ApplicationUserManager UserManager { get; }

        /// <summary>
        /// Access to class with user's client profiles management
        /// </summary>
        IClientManager ClientManager { get; }

        /// <summary>
        /// Access to class with roles management
        /// </summary>
        ApplicationRoleManager RoleManager { get; }

        void Save();
    }
}
