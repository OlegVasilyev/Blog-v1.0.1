using AuthenticationLayerBLL.Interface.DTO;
using AuthenticationLayerBLL.Interface.Infrastructure;
using AuthenticationLayerBLL.Interface.Interfaces;
using Entities.IdentityEnties;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using ValidationLayer.InfrastructureAL;
using System.Linq;
using System.Security.Claims;
using AuthenticationLayerDAL.Interface.Interfaces;

namespace AuthenticationLayerBLL.Services
{
    public class UserService : IUserService
    {
        IAuthenticationRepository _database;

        public UserService(IAuthenticationRepository uow)
        {
            _database = uow;
        }

        public OperationDetails Create(UserDTO userDto)
        {
            OperationDetails validationResult = Validator.ValidateUser(userDto);
            if (validationResult.Succedeed == false)
                return validationResult;
            ApplicationUser user = _database.UserManager.FindByEmail(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                IdentityResult result = _database.UserManager.Create(user, userDto.Password);
                if (result.Errors.Any())
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                // Add role
                _database.UserManager.AddToRole(user.Id, userDto.Role);
                // Create user profile
                var clientProfile = new ClientProfile { Id = user.Id, Name = userDto.Name };
                _database.ClientManager.Create(clientProfile);
                _database.Save();
                return new OperationDetails(true, "Registration succeed", "");
            }
            return new OperationDetails(false, "User with such login already exists", "Email");
        }

        public IEnumerable<UserDTO> GetAll()
        {
            List<UserDTO> usersDto = new List<UserDTO>();
            IEnumerable<ApplicationUser> users = _database.UserManager.Users.ToList();
            foreach (var user in users)
            {
                string role = _database.RoleManager.FindById(user.Roles.Last().RoleId).Name;
                usersDto.Add(new UserDTO
                {
                    UserName = user.Email,
                    Name = user.ClientProfile.Name,
                    Email = user.Email,
                    Id = user.Id,
                    Role = role
                });
            }
            return usersDto;
        }

        public UserDTO Get(string id)
        {
            ApplicationUser user = _database.UserManager.FindById(id);
            if (user != null)
            {
                var role = _database.RoleManager.FindById(user.Roles.Last().RoleId);
                string roleName = null;
                if (role != null)
                    roleName = role.Name;
                return new UserDTO
                {
                    UserName = user.Email,
                    Name = user.ClientProfile.Name,
                    Email = user.Email,
                    Id = user.Id,
                    Role = roleName
                };
            }
            return null;
        }

        public OperationDetails SetRole(UserDTO userDto, string roleName)
        {
            if (string.IsNullOrEmpty(userDto?.Email))
                return new OperationDetails(false, "Email cannot be empty", "Email");
            if (string.IsNullOrEmpty(roleName))
                return new OperationDetails(false, "Role cannot be empty", "");
            // Search for user
            ApplicationUser user = _database.UserManager.FindByEmail(userDto.Email);
            if (user != null)
            {
                // Removing old roles
                _database.UserManager.RemoveFromRoles(user.Id, _database.UserManager.GetRoles(user.Id).ToArray());
                var role = _database.RoleManager.FindByName(roleName);
                // If the role has already existed
                if (role != null)
                {
                    _database.UserManager.AddToRole(user.Id, roleName);
                    _database.Save();
                    return new OperationDetails(true, "Role successfuly set", "");
                }
                // If the role has NOT existed
                _database.RoleManager.Create(new ApplicationRole { Name = roleName });
                _database.UserManager.AddToRole(user.Id, roleName);
                _database.Save();
                return new OperationDetails(true, "Role successfuly created and setted", "");
            }
            return new OperationDetails(false, "User wasn't found", "");
        }

        public ClaimsIdentity Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // Search for user
            ApplicationUser user = _database.UserManager.Find(userDto.Email, userDto.Password);
            // Authorize user and return ClaimsIdentity object
            if (user != null)
                claim = _database.UserManager.CreateIdentity(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}