using IdentityTest1.Models.Autenticação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Diagnostics;


namespace IdentityTest1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public async Task<ActionResult> Index()
        {

            var contexto = HttpContext.GetOwinContext();
            var login = contexto.GetUserManager<ApplicationSignInManager>();

            var result = await login.PasswordSignInAsync("gscarvalho", "minhasenha123", false, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return Redirect("/Home");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = "/Home", RememberMe = false });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
            }
            

            return View();
        }

        private ApplicationUser ApplicationUser()
        {
            throw new NotImplementedException();
        }
    }
}