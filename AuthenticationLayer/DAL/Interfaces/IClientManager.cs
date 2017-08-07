using Entities.IdentityEnties;
using System;

namespace AuthenticationLayer.DAL.Interfaces
{
    /// <summary>
    /// Describes interaction with client profile
    /// </summary>
    public interface IClientManager : IDisposable
    {
        /// <summary>
        /// Creates new client profile
        /// </summary>
        /// <param name="item">Profile to create</param>
        void Create(ClientProfile item);
    }
}
