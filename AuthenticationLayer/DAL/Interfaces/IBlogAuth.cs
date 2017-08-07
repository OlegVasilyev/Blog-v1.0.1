using AuthenticationLayer.DAL.Identity;
using System;

namespace AuthenticationLayer.DAL.Interfaces
{
    /// <summary>
    /// Interface for implementation of unit of work pattern.
    /// Presantation layer will work with Auth using this interface.
    /// Simply: unite all the implementations of generic repository together in one place.
    /// </summary>
    public interface IBlogAuth : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        void Save();
    }
}
