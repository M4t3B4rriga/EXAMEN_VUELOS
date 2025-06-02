using ClienteEscritorioVuelos.ec.edu.monster.modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClienteEscritorioVuelos.ec.edu.monster.controlador
{
    public class ApiController
    {
        private readonly HttpClient client;

        public ApiController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://10.40.20.28/"); // Cambia según tu IP/URL
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // 🔐 Login con API
        public async Task<Usuario> LoginApi(string email, string contrasena)
        {
            var datos = new { email = email, contrasena = contrasena };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Usuarios/login", jsonContent);

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Usuario>(json);
        }

        // 📋 Registrar usuario
        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Usuarios", jsonContent);
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Usuario>(json);
        }

        // ✈️ Buscar vuelos
        public async Task<List<Vuelo>> BuscarVuelos(string origen, string destino)
        {
            var response = await client.GetAsync($"api/Vuelos/buscar?origen={origen}&destino={destino}");
            if (!response.IsSuccessStatusCode) return new List<Vuelo>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Vuelo>>(json);
        }

        // 🛒 Comprar boletos
        public async Task<string> ComprarBoletos(int idUsuario, int idVuelo, int numeroAsientos)
        {
            var response = await client.PostAsync($"api/Compras/comprar?idUsuario={idUsuario}&idVuelo={idVuelo}&numeroAsientos={numeroAsientos}", null);
            return await response.Content.ReadAsStringAsync();
        }

        // 🎟️ Mostrar boletos por usuario
        public async Task<List<Boleto>> MostrarBoletosUsuario(int idUsuario)
        {
            var response = await client.GetAsync($"api/Boletos/usuario/{idUsuario}");
            if (!response.IsSuccessStatusCode) return new List<Boleto>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Boleto>>(json);
        }

        // ✈️ Mostrar todos los vuelos
        public async Task<List<Vuelo>> MostrarTodosVuelos()
        {
            var response = await client.GetAsync("api/Vuelos");
            if (!response.IsSuccessStatusCode) return new List<Vuelo>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Vuelo>>(json);
        }

        // 🔍 Obtener ID usuario por email
        public async Task<int> ObtenerIdUsuarioPorEmail(string email)
        {
            var response = await client.GetAsync($"api/Usuarios/email/{email}");
            if (!response.IsSuccessStatusCode) return -1;

            var idStr = await response.Content.ReadAsStringAsync();
            return int.Parse(idStr);
        }
    }
}