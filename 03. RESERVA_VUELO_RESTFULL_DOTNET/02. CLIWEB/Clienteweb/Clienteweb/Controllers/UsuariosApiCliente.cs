using ClienteConsolaVuelos.ec.edu.monster.modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Clienteweb.Controllers
{
    public class UsuariosApiCliente
    {
        private readonly HttpClient client;

        public UsuariosApiCliente()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://10.40.20.28/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Vuelo>> BuscarVuelos(string origen, string destino)
        {
            var response = await client.GetAsync($"api/Vuelos/buscar?origen={origen}&destino={destino}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Vuelo>>(json);
        }

        public async Task<string> ComprarBoletos(int idUsuario, int idVuelo, int numeroAsientos)
        {
            var response = await client.PostAsync($"api/Compras/comprar?idUsuario={idUsuario}&idVuelo={idVuelo}&numeroAsientos={numeroAsientos}", null);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<Boleto>> MostrarBoletosUsuario(int idUsuario)
        {
            var response = await client.GetAsync($"api/Boletos/usuario/{idUsuario}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Boleto>>(json);
        }

        public async Task<List<Vuelo>> MostrarTodosVuelos()
        {
            var response = await client.GetAsync("api/Vuelos");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Vuelo>>(json);
        }

        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Usuarios", jsonContent);
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Usuario>(json);
        }


        public async Task<Usuario> Login(string email, string contrasena)
        {
            var datos = new { email = email, contrasena = contrasena };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Usuarios/login", jsonContent);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Usuario>(json);
        }

        public async Task<int> ObtenerIdUsuarioPorEmail(string email)
        {
            var response = await client.GetAsync($"api/Usuarios/email/{email}");
            if (!response.IsSuccessStatusCode) return -1;
            var idStr = await response.Content.ReadAsStringAsync();
            return int.Parse(idStr);
        }
    }
}