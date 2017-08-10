using AuthenticationLayerBLL.Interface.DTO;
using AuthenticationLayerBLL.Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthenticationLayerBLL.Interface.Interfaces
{
    public interface IUserService : IDisposable
    {
        /// <summary>
        /// Creates related ApplicationUser & ClientProfile in db
        /// </summary>
        /// <param name="userDto">Stores info about user to create</param>
        /// <returns>Class with creating result details</returns>
        OperationDetails Create(UserDTO userDto);

        /// <summary>
        /// Gives all users from db
        /// </summary>
        /// <returns>All users from db</returns>
        IEnumerable<UserDTO> GetAll();

        UserDTO Get(string id);

        /// <summary>
        /// Sets specified role to user
        /// Removes all other roles!
        /// </summary>
        /// <param name="userDto">User to set role of</param>
        /// <param name="role">Role to set</param>
        /// <returns>Class with role setting result details</returns>
        OperationDetails SetRole(UserDTO userDto, string role);

        /// <summary>
        /// Provide user authentification
        /// </summary>
        /// <param name="userDto">User to authenticate</param>
        /// <returns>User's claims</returns>
        ClaimsIdentity Authenticate(UserDTO userDto);
    }
}
