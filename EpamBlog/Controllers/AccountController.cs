using EpamBlog.Models;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using AuthenticationLayerBLL.Interface.Interfaces;
using AuthenticationLayerBLL.Interface.DTO;
using AuthenticationLayerBLL.Interface.Infrastructure;

namespace EpamBlog.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService service)
        {

            _userService = service;
            _userService.Create(new UserDTO
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                Password = "admin123",
                Name = "Admin",
                Role = "admin",
            });
        }
        private IAuthenticationManager AuthenticationManager =>
            HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            
            if (ModelState.IsValid)
            {
                var userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = _userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Invalid login or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = _userService.Create(userDto);

                if (!operationDetails.Succedeed)
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);

                return View("SuccessRegister");
            }
            return View(model);
        }
    }
}