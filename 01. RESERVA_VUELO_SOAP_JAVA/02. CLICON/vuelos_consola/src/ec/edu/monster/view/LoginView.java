package ec.edu.monster.view;

import java.util.Scanner;

public class LoginView {
    private final Scanner scanner = new Scanner(System.in);

    public String[] mostrarLogin() {
        System.out.println("===== LOGIN =====");
        System.out.print("Email: ");
        String email = scanner.nextLine();
        System.out.print("Contraseña: ");
        String contrasena = scanner.nextLine();
        return new String[]{email, contrasena};
    }

    public void mostrarErrorLogin() {
        System.out.println("Error: Email o contraseña incorrectos.");
    }

    public void mostrarBienvenida(String email) {
        System.out.println("Bienvenido, " + email + "!");
    }
}
