/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ec.edu.monster.model;
import ec.edu.monster.controller.WSVuelo_Service;
import ec.edu.monster.controller.WSVuelo;
import ec.edu.monster.controller.Boleto;
import ec.edu.monster.controller.Vuelo;
import java.util.GregorianCalendar;
import java.util.List;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
/**
 *
 * @author sebas
 */
public class VueloClient {
    public static boolean login(String email, String contrasena) {
        WSVuelo_Service service = new WSVuelo_Service();
        WSVuelo port = service.getWSVueloPort();
        return port.login(email, contrasena);
    }

    public static int registrarUsuario(String nombreUsuario, String apellidoUsuario, String cedula, String celular, String email, String contrasena) {
        WSVuelo_Service service = new WSVuelo_Service();
        WSVuelo port = service.getWSVueloPort();
        return port.registrarUsuario(nombreUsuario, apellidoUsuario, cedula, celular, email, contrasena);
    }

    public static List<Vuelo> buscarVuelos(String ciudadOrigen, String ciudadDestino, java.util.Date fecha) {
        WSVuelo_Service service = new WSVuelo_Service();
        WSVuelo port = service.getWSVueloPort();
        try {
            GregorianCalendar gcal = new GregorianCalendar();
            gcal.setTime(fecha);
            XMLGregorianCalendar xmlFecha = DatatypeFactory.newInstance().newXMLGregorianCalendar(gcal);
            return port.buscarVuelos(ciudadOrigen, ciudadDestino, xmlFecha);
        } catch (Exception e) {
            throw new RuntimeException("Error al convertir fecha: " + e.getMessage());
        }
    }

    public static int comprarBoletos(int idUsuario, int idVuelo, int numeroAsientos) {
        WSVuelo_Service service = new WSVuelo_Service();
        WSVuelo port = service.getWSVueloPort();
        return port.comprarBoletos(idUsuario, idVuelo, numeroAsientos);
    }

    public static List<Boleto> mostrarBoletosUsuario(int idUsuario) {
        WSVuelo_Service service = new WSVuelo_Service();
        WSVuelo port = service.getWSVueloPort();
        return port.mostrarBoletosUsuario(idUsuario);
    }

    public static List<Vuelo> mostrarTodosVuelos() {
        WSVuelo_Service service = new WSVuelo_Service();
        WSVuelo port = service.getWSVueloPort();
        return port.mostrarTodosVuelos();
    }

    public static int obtenerIdUsuarioPorEmail(String email) {
        WSVuelo_Service service = new WSVuelo_Service();
        WSVuelo port = service.getWSVueloPort();
        return port.obtenerIdUsuarioPorEmail(email);
    }
}
