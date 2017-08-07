using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Entities.IdentityEnties;

namespace AuthenticationLayer.DAL.Context
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
        public AuthenticationContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }

}
