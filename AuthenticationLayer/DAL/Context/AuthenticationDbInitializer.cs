using System.Data.Entity;

namespace AuthenticationLayer.DAL.Context
{
    /// <summary>
    /// Drops database on each restart of the server
    /// Should be changed/removed before deployment
    /// </summary>
    class AuthenticationDbInitializer : DropCreateDatabaseAlways<AuthenticationContext>
    {
        protected override void Seed(AuthenticationContext db)
        {
        }
    }
}
