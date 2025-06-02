using System.Threading.Tasks;
using System.Web.Mvc;
using ClienteConsolaVuelos.ec.edu.monster.modelo;

namespace Clienteweb.Controllers
{
    public class VuelosController : Controller
    {
        private readonly UsuariosApiCliente api = new UsuariosApiCliente();

        public ActionResult BuscarVuelos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> BuscarVuelos(string origen, string destino)
        {
            var vuelos = await api.BuscarVuelos(origen, destino);
            ViewBag.Vuelos = vuelos;
            return View();
        }

        public ActionResult ComprarBoletos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ComprarBoletos(int idUsuario, int idVuelo, int numeroAsientos)
        {
            var resultado = await api.ComprarBoletos(idUsuario, idVuelo, numeroAsientos);
            ViewBag.Mensaje = resultado;
            return View();
        }

        public ActionResult MostrarBoletos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> MostrarBoletos(int idUsuario)
        {
            var boletos = await api.MostrarBoletosUsuario(idUsuario);
            ViewBag.Boletos = boletos;
            return View();
        }

        public ActionResult MostrarTodosVuelos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> MostrarTodosVuelos(FormCollection form)
        {
            var vuelos = await api.MostrarTodosVuelos();
            ViewBag.Vuelos = vuelos;
            return View();
        }

        public ActionResult ObtenerIdPorEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerIdPorEmail(string email)
        {
            var id = await api.ObtenerIdUsuarioPorEmail(email);
            ViewBag.IdUsuario = id;
            return View();
        }
    }
}
