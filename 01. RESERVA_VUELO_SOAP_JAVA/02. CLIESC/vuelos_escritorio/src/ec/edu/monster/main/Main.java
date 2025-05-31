/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ec.edu.monster.main;
import ec.edu.monster.view.LoginWindow;
/**
 *
 * @author sebas
 */
public class Main {
     public static void main(String[] args) {
        // Ensure GUI is created on the Event Dispatch Thread
        javax.swing.SwingUtilities.invokeLater(() -> {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.setVisible(true);
        });
    }
}
