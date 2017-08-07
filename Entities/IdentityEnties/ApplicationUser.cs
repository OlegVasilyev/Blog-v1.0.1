using Microsoft.AspNet.Identity.EntityFramework;

namespace Entities.IdentityEnties
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
