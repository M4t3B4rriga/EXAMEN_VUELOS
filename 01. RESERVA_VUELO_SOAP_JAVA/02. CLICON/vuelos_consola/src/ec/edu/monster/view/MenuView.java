package ec.edu.monster.view;

import java.util.Scanner;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Scanner;
import java.util.List;

public class MenuView {
    private final Scanner scanner = new Scanner(System.in);

    public int mostrarMenuInicial() {
        System.out.println("\n===== BIENVENIDO A VIAJECITOS S.A. =====");
        System.out.println("1. Iniciar sesión");
        System.out.println("2. Registrarse");
        System.out.println("0. Salir");
        System.out.print("Seleccione una opción: ");
        try {
            return Integer.parseInt(scanner.nextLine());
        } catch (NumberFormatException e) {
            return -1;
        }
    }

    public int mostrarMenu() {
        System.out.println("\n===== MENÚ PRINCIPAL =====");
        System.out.println("1. Buscar vuelos");
        System.out.println("2. Comprar boletos");
        System.out.println("3. Mostrar mis boletos");
        System.out.println("4. Mostrar todos los vuelos");
        System.out.println("0. Salir");
        System.out.print("Seleccione una opción: ");
        try {
            return Integer.parseInt(scanner.nextLine());
        } catch (NumberFormatException e) {
            return -1;
        }
    }

    public String[] pedirDatosBusquedaVuelos() {
        System.out.print("Ciudad origen (e.g., MEX): ");
        String ciudadOrigen = scanner.nextLine();
        System.out.print("Ciudad destino (e.g., CUN): ");
        String ciudadDestino = scanner.nextLine();
        System.out.print("Fecha (YYYY-MM-DD): ");
        String fecha = scanner.nextLine();
        return new String[]{ciudadOrigen, ciudadDestino, fecha};
    }

    public String[] pedirDatosCompraBoletos() {
        System.out.print("ID de vuelo: ");
        String idVuelo = scanner.nextLine();
        System.out.print("Número de asientos: ");
        String numeroAsientos = scanner.nextLine();
        return new String[]{idVuelo, numeroAsientos};
    }

    public String[] pedirDatosRegistroUsuario() {
        System.out.println("===== REGISTRO DE USUARIO =====");
        System.out.print("Nombre: ");
        String nombre = scanner.nextLine();
        System.out.print("Apellido: ");
        String apellido = scanner.nextLine();
        System.out.print("Cédula: ");
        String cedula = scanner.nextLine();
        System.out.print("Celular: ");
        String celular = scanner.nextLine();
        System.out.print("Email: ");
        String email = scanner.nextLine();
        System.out.print("Contraseña: ");
        String contrasena = scanner.nextLine();
        return new String[]{nombre, apellido, cedula, celular, email, contrasena};
    }

    public void mostrarVuelos(List<ec.edu.monster.controller.Vuelo> vuelos) {
        System.out.println("\n=== VUELOS ENCONTRADOS ===");
        if (vuelos.isEmpty()) {
            System.out.println("No se encontraron vuelos.");
            return;
        }
        System.out.println("ID\tOrigen\tDestino\tValor\t\tFecha Salida\t\tAsientos Disponibles");
        System.out.println("--------------------------------------------------------------------------------");
        for (ec.edu.monster.controller.Vuelo vuelo : vuelos) {
            System.out.printf("%d\t%s\t%s\t%.2f\t%s\t%d\n",
                    vuelo.getIdVuelo(), vuelo.getCiudadOrigen(), vuelo.getCiudadDestino(),
                    vuelo.getValor(), vuelo.getHoraSalida().toString(), vuelo.getAsientosDisponibles());
        }
    }

    public void mostrarBoletos(List<ec.edu.monster.controller.Boleto> boletos) {
        System.out.println("\n=== MIS BOLETOS ===");
        if (boletos.isEmpty()) {
            System.out.println("No se encontraron boletos.");
            return;
        }
        System.out.println("ID Boleto\tID Vuelo\tFecha Compra\t\tAsiento\t\tValor");
        System.out.println("--------------------------------------------------------------------------------");
        for (ec.edu.monster.controller.Boleto boleto : boletos) {
            System.out.printf("%d\t\t%d\t\t%s\t%s\t%.2f\n",
                    boleto.getIdBoleto(), boleto.getIdVuelo(), boleto.getFechaCompra().toString(),
                    boleto.getNumeroAsiento(), boleto.getValor());
        }
    }

    public void mostrarMensaje(String mensaje) {
        System.out.println(mensaje);
    }
}
