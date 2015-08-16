using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using IdentityTest1.Models.Autenticação;
using System.Diagnostics;

namespace IdentityTest1.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // O certo é aqui ser HttpPost, porém como é uma aplicação de teste e não vou implementar a view;
        [HttpGet]
        public async Task<ActionResult> Cadastrar()
        {

            //Valer ver o Startup.Auth ( foi lá que inserimos o Contexto );
            var contexto = HttpContext.GetOwinContext();
            var manager = contexto.GetUserManager<ApplicationUserManager>();

            try
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "gustavoscarvalho@yahoo.com.br",
                    UserName = "gscarvalho"
                };

                var result = await manager.CreateAsync(user,"minhasenha123");
                if (result.Succeeded)
                {
                    //Se entrar aqui o cadastro deu certo, veja no banco!
                    Debug.WriteLine("Debugando");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return View();
        }
    }
}