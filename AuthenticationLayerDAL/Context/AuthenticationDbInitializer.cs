using Entities.IdentityEnties;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace AuthenticationLayerDAL.Context
{
    /// <summary>
    /// Drops database on each restart of the server
    /// Should be changed/removed before deployment
    /// </summary>
    class AuthenticationDbInitializer : DropCreateDatabaseAlways<AuthenticationContext>
    {
        protected override void Seed(AuthenticationContext db)
        {
            db.Roles.Add(new IdentityRole("user"));
            db.Roles.Add(new IdentityRole("admin"));
        }
    }
}
