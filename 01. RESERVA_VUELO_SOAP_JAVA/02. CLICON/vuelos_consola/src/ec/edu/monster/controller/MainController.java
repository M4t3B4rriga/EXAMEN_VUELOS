package ec.edu.monster.controller;

import ec.edu.monster.model.VueloClient;
import ec.edu.monster.view.LoginView;
import ec.edu.monster.view.MenuView;
import java.text.SimpleDateFormat;
import java.util.Date;

public class MainController {
    private final LoginView loginView = new LoginView();
    private final MenuView menuView = new MenuView();

    public void iniciarAplicacion() {
        boolean salir = false;
        String email = "";
        int idUsuario = -1;

        while (!salir) {
            int opcion = menuView.mostrarMenuInicial();
            switch (opcion) {
                case 1 -> { // Iniciar sesión
                    String[] datos = loginView.mostrarLogin();
                    if (VueloClient.login(datos[0], datos[1])) {
                        email = datos[0];
                        idUsuario = VueloClient.obtenerIdUsuarioPorEmail(email);
                        if (idUsuario == -1) {
                            loginView.mostrarErrorLogin();
                            continue;
                        }
                        loginView.mostrarBienvenida(email);
                        mostrarMenuPrincipal(idUsuario);
                    } else {
                        loginView.mostrarErrorLogin();
                    }
                }
                case 2 -> { // Registrarse
                    String[] datos = menuView.pedirDatosRegistroUsuario();
                    try {
                        int r = VueloClient.registrarUsuario(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5]);
                        menuView.mostrarMensaje("Registro de usuario: " + (r == 1 ? "Éxito" : "Fallo"));
                    } catch (Exception e) {
                        menuView.mostrarMensaje("Error al registrar usuario: " + e.getMessage());
                    }
                }
                case 0 -> {
                    salir = true;
                    menuView.mostrarMensaje("Gracias por usar el sistema.");
                }
                default -> menuView.mostrarMensaje("Opción no válida.");
            }
        }
    }

    private void mostrarMenuPrincipal(int idUsuario) {
        boolean salir = false;
        while (!salir) {
            int opcion = menuView.mostrarMenu();
            switch (opcion) {
                case 1 -> { // Buscar vuelos
                    String[] datos = menuView.pedirDatosBusquedaVuelos();
                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date fecha = sdf.parse(datos[2]);
                        var vuelos = VueloClient.buscarVuelos(datos[0], datos[1], fecha);
                        menuView.mostrarVuelos(vuelos);
                    } catch (Exception e) {
                        menuView.mostrarMensaje("Error al buscar vuelos: " + e.getMessage());
                    }
                }
                case 2 -> { // Comprar boletos
                    String[] datos = menuView.pedirDatosCompraBoletos();
                    try {
                        int r = VueloClient.comprarBoletos(
                                idUsuario,
                                Integer.parseInt(datos[0]),
                                Integer.parseInt(datos[1]));
                        menuView.mostrarMensaje("Compra de boletos: " + (r == 1 ? "Éxito" : "Fallo"));
                    } catch (Exception e) {
                        menuView.mostrarMensaje("Error al comprar boletos: " + e.getMessage());
                    }
                }
                case 3 -> { // Mostrar mis boletos
                    try {
                        var boletos = VueloClient.mostrarBoletosUsuario(idUsuario);
                        menuView.mostrarBoletos(boletos);
                    } catch (Exception e) {
                        menuView.mostrarMensaje("Error al obtener boletos: " + e.getMessage());
                    }
                }
                case 4 -> { // Mostrar todos los vuelos
                    try {
                        var vuelos = VueloClient.mostrarTodosVuelos();
                        menuView.mostrarVuelos(vuelos);
                    } catch (Exception e) {
                        menuView.mostrarMensaje("Error al obtener vuelos: " + e.getMessage());
                    }
                }
                case 0 -> {
                    salir = true;
                    menuView.mostrarMensaje("Cerrando sesión.");
                }
                default -> menuView.mostrarMensaje("Opción no válida.");
            }
        }
    }
}
