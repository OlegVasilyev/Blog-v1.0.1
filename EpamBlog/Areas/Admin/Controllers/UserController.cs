using AuthenticationLayer.BLL.Interfaces;
using System.Web.Mvc;

namespace EpamBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}