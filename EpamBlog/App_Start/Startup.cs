using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using EpamBlog.App_Start;
using Microsoft.AspNet.Identity;
using AuthenticationLayerBLL.Interface.Interfaces;
using AuthenticationLayerBLL.Services;

[assembly: OwinStartup(typeof(Startup))]

namespace EpamBlog.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
        private IUserService CreateUserService()
        {
            return new ServiceCreator().CreateUserService();
        }
    }
}