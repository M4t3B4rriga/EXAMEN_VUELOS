using ClienteConsolaVuelos.ec.edu.monster.controlador;
using ClienteConsolaVuelos.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteConsolaVuelos
{
    internal class Program
    {
        static Usuario usuarioLogueado = null;

        static async Task Main(string[] args)
        {
            // Login inicial quemado
            if (!LoginInicial())
            {
                Console.WriteLine("Acceso denegado. El programa se cerrará.");
                return;
            }

            var api = new ClienteAPI();

            while (true)
            {
                if (usuarioLogueado == null)
                {
                    Console.WriteLine("\n=== Inicio de Sesion Aerolinea ===");
                    Console.WriteLine("1. Iniciar sesión");
                    Console.WriteLine("2. Registrarse");
                    Console.WriteLine("0. Salir");
                    Console.Write("Opción: ");
                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            await Login(api);
                            break;
                        case "2":
                            await Registro(api);
                            Console.WriteLine("\nPor favor, inicia sesión para continuar.");
                            await Login(api);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n=== Menú Principal ===");
                    Console.WriteLine("3. Buscar vuelos");
                    Console.WriteLine("4. Comprar boletos");
                    Console.WriteLine("5. Mostrar mis boletos");
                    Console.WriteLine("6. Mostrar todos los vuelos");
                    Console.WriteLine("7. Obtener ID de usuario por email");
                    Console.WriteLine("0. Salir");
                    Console.Write("Opción: ");
                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "3":
                            await BuscarVuelos(api);
                            break;
                        case "4":
                            await ComprarBoletos(api);
                            break;
                        case "5":
                            await MostrarBoletos(api);
                            break;
                        case "6":
                            await MostrarTodosVuelos(api);
                            break;
                        case "7":
                            await ObtenerIdPorEmail(api);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
            }
        }

        static bool LoginInicial()
        {
            Console.WriteLine("\n=== Login de Seguridad ===");
            Console.Write("Usuario: ");
            string usuario = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            if (usuario.ToUpper() == "MONSTER" && contrasena == "MONSTER9")
            {
                Console.WriteLine("¡Login exitoso!");
                return true;
            }
            else
            {
                Console.WriteLine("Credenciales incorrectas.");
                return false;
            }
        }

        static async Task Login(ClienteAPI api)
        {
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Contraseña: ");
            var pass = Console.ReadLine();
            var user = await api.Login(email, pass);
            if (user != null)
            {
                usuarioLogueado = user;
                Console.WriteLine($"Bienvenido {user.nombre_usuario} {user.apellido_usuario}");
            }
            else
            {
                Console.WriteLine("Login fallido.");
            }
        }

        static async Task Registro(ClienteAPI api)
        {
            var u = new Usuario();
            Console.Write("Nombre: "); u.nombre_usuario = Console.ReadLine();
            Console.Write("Apellido: "); u.apellido_usuario = Console.ReadLine();
            Console.Write("Cédula: "); u.cedula = Console.ReadLine();
            Console.Write("Celular: "); u.celular = Console.ReadLine();
            Console.Write("Email: "); u.email = Console.ReadLine();
            Console.Write("Contraseña: "); u.contrasena = Console.ReadLine();

            var result = await api.RegistrarUsuario(u);
            if (result != null)
            {
                Console.WriteLine($"Usuario registrado correctamente:");
                Console.WriteLine($"ID: {result.id_usuario} | Nombre: {result.nombre_usuario} {result.apellido_usuario} | Email: {result.email}");
            }
            else
            {
                Console.WriteLine("Error al registrar usuario.");
            }
        }

        static async Task BuscarVuelos(ClienteAPI api)
        {
            Console.Write("Origen: ");
            var o = Console.ReadLine();
            Console.Write("Destino: ");
            var d = Console.ReadLine();
            Console.Write("Fecha del vuelo (YYYY-MM-DD): ");
            var fechaInput = Console.ReadLine();

            if (!DateTime.TryParse(fechaInput, out DateTime fechaSeleccionada))
            {
                Console.WriteLine("Formato de fecha inválido. Usa YYYY-MM-DD.");
                return;
            }

            var vuelos = await api.BuscarVuelos(o, d);

            var vuelosFiltrados = vuelos.Where(v => v.hora_salida.Date == fechaSeleccionada.Date).ToList();

            if (vuelosFiltrados.Any())
            {
                foreach (var v in vuelosFiltrados)
                    Console.WriteLine($"{v.id_vuelo} | {v.ciudad_origen}->{v.ciudad_destino} | ${v.valor} | Asientos: {v.asientos_disponibles} | Salida: {v.hora_salida}");
            }
            else
            {
                Console.WriteLine("No se encontraron vuelos para la fecha seleccionada.");
            }
        }

        static async Task ComprarBoletos(ClienteAPI api)
        {
            if (usuarioLogueado == null) { Console.WriteLine("Debe iniciar sesión."); return; }
            Console.Write("ID de Vuelo: ");
            var idVuelo = int.Parse(Console.ReadLine());
            Console.Write("Número de asientos: ");
            var asientos = int.Parse(Console.ReadLine());
            var result = await api.ComprarBoletos(usuarioLogueado.id_usuario, idVuelo, asientos);
            Console.WriteLine(result);
        }

        static async Task MostrarBoletos(ClienteAPI api)
        {
            if (usuarioLogueado == null) { Console.WriteLine("Debe iniciar sesión."); return; }
            var boletos = await api.MostrarBoletosUsuario(usuarioLogueado.id_usuario);
            foreach (var b in boletos)
                Console.WriteLine($"{b.id_boleto} | Vuelo: {b.id_vuelo} | Asiento: {b.numero_asiento} | Fecha: {b.fecha_compra}");
        }

        static async Task MostrarTodosVuelos(ClienteAPI api)
        {
            var vuelos = await api.MostrarTodosVuelos();
            foreach (var v in vuelos)
                Console.WriteLine($"{v.id_vuelo} | {v.ciudad_origen}->{v.ciudad_destino} | ${v.valor} | Asientos: {v.asientos_disponibles}");
        }

        static async Task ObtenerIdPorEmail(ClienteAPI api)
        {
            Console.Write("Email: ");
            var email = Console.ReadLine();
            var id = await api.ObtenerIdUsuarioPorEmail(email);
            Console.WriteLine($"ID del usuario: {id}");
        }
    }
}
