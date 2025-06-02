using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clienteweb.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Index(string usuario, string contrasena)
        {
            if (usuario.ToUpper() == "MONSTER" && contrasena == "MONSTER9")
            {
                return RedirectToAction("Menu", "Login");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View();
            }
        }

        public ActionResult Menu()
        {
            return View("~/Views/Home/Menu.cshtml");
        }
    }
}