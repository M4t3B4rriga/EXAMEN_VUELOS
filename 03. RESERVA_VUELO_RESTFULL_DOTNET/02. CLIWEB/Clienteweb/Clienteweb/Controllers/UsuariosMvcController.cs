using System.Threading.Tasks;
using System.Web.Mvc;
using ClienteConsolaVuelos.ec.edu.monster.modelo;

namespace Clienteweb.Controllers
{
    public class UsuariosMvcController : Controller
    {
        private readonly UsuariosApiCliente api = new UsuariosApiCliente();

        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IniciarSesion(string email, string contrasena)
        {
            var usuario = await api.Login(email, contrasena);
            if (usuario != null)
            {
                // Guarda el usuario en una sesión temporal si quieres
                Session["UsuarioLogueado"] = usuario;

                // Redirige al menú principal
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                ViewBag.Error = "Credenciales inválidas. Intente nuevamente.";
                return View();
            }
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(Usuario usuario)
        {
            var resultado = await api.RegistrarUsuario(usuario);
            if (resultado != null)
            {
                ViewBag.Mensaje = "Usuario registrado correctamente.";
            }
            else
            {
                ViewBag.Error = "Error al registrar el usuario.";
            }
            return View();
        }
    }
}
