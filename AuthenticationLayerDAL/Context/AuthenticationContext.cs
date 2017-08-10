using Entities.IdentityEnties;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AuthenticationLayerDAL.Context
{
    /// <summary>
    /// Static constructor for setting DB initializer
    /// </summary>
    public class AuthenticationContext : IdentityDbContext<ApplicationUser>
    {
        static AuthenticationContext()
        {
            Database.SetInitializer(new AuthenticationDbInitializer());
        }
        public AuthenticationContext() : base("AuthenticationContext")
        {
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }

}
