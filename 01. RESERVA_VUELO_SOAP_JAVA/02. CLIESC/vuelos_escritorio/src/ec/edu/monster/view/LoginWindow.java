/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ec.edu.monster.view;

import ec.edu.monster.model.VueloClient;
import ec.edu.monster.view.MainWindow;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
/**
 *
 * @author sebas
 */
public class LoginWindow extends JFrame{
    private JTextField emailField;
    private JPasswordField passwordField;
    private JTextField nombreField;
    private JTextField apellidoField;
    private JTextField cedulaField;
    private JTextField celularField;
    private JTextField regEmailField;
    private JPasswordField regPasswordField;
    private JPanel loginPanel;
    private JPanel registerPanel;
    private JTabbedPane tabbedPane;
    private MainWindow mainWindow;

    public LoginWindow() {
        setTitle("Viajecitos S.A. - Bienvenida");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        
        // Create background panel
        BackgroundImagePanel backgroundPanel = new BackgroundImagePanel("login.jpg");
        backgroundPanel.setLayout(new BorderLayout());
        tabbedPane = new JTabbedPane();

        // Login Panel
        loginPanel = new JPanel(new GridLayout(3, 2, 10, 10));
        loginPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));
        loginPanel.setOpaque(false);
        loginPanel.add(new JLabel("Email:"));
        emailField = new JTextField();
        loginPanel.add(emailField);
        loginPanel.add(new JLabel("Contraseña:"));
        passwordField = new JPasswordField();
        loginPanel.add(passwordField);
        JButton loginButton = new JButton("Iniciar Sesión");
        loginPanel.add(loginButton);
        JButton exitButton = new JButton("Salir");
        loginPanel.add(exitButton);

        // Register Panel
        registerPanel = new JPanel(new GridLayout(7, 2, 10, 10));
        registerPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));
        registerPanel.setOpaque(false);
        registerPanel.add(new JLabel("Nombre:"));
        nombreField = new JTextField();
        registerPanel.add(nombreField);
        registerPanel.add(new JLabel("Apellido:"));
        apellidoField = new JTextField();
        registerPanel.add(apellidoField);
        registerPanel.add(new JLabel("Cédula:"));
        cedulaField = new JTextField();
        registerPanel.add(cedulaField);
        registerPanel.add(new JLabel("Celular:"));
        celularField = new JTextField();
        registerPanel.add(celularField);
        registerPanel.add(new JLabel("Email:"));
        regEmailField = new JTextField();
        registerPanel.add(regEmailField);
        registerPanel.add(new JLabel("Contraseña:"));
        regPasswordField = new JPasswordField();
        registerPanel.add(regPasswordField);
        JButton registerButton = new JButton("Registrarse");
        registerPanel.add(registerButton);
        JButton backButton = new JButton("Volver");
        registerPanel.add(backButton);

        tabbedPane.addTab("Iniciar Sesión", loginPanel);
        tabbedPane.addTab("Registrarse", registerPanel);
        add(tabbedPane);

        // Action Listeners
        loginButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String email = emailField.getText();
                String password = new String(passwordField.getPassword());
                if (VueloClient.login(email, password)) {
                    int idUsuario = VueloClient.obtenerIdUsuarioPorEmail(email);
                    if (idUsuario != -1) {
                        mainWindow = new MainWindow(idUsuario);
                        mainWindow.setVisible(true);
                        dispose();
                    } else {
                        JOptionPane.showMessageDialog(LoginWindow.this, "Error: No se pudo obtener ID de usuario.", "Error", JOptionPane.ERROR_MESSAGE);
                    }
                } else {
                    JOptionPane.showMessageDialog(LoginWindow.this, "Error: Email o contraseña incorrectos.", "Error", JOptionPane.ERROR_MESSAGE);
                }
            }
        });

        registerButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String nombre = nombreField.getText();
                String apellido = apellidoField.getText();
                String cedula = cedulaField.getText();
                String celular = celularField.getText();
                String email = regEmailField.getText();
                String password = new String(regPasswordField.getPassword());
                try {
                    int result = VueloClient.registrarUsuario(nombre, apellido, cedula, celular, email, password);
                    JOptionPane.showMessageDialog(LoginWindow.this, "Registro de usuario: " + (result == 1 ? "Éxito" : "Fallo"), "Resultado", JOptionPane.INFORMATION_MESSAGE);
                    if (result == 1) {
                        tabbedPane.setSelectedIndex(0); // Switch back to login tab
                        clearRegisterFields();
                    }
                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(LoginWindow.this, "Error al registrar usuario: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
                }
            }
        });

        exitButton.addActionListener(e -> System.exit(0));
        backButton.addActionListener(e -> tabbedPane.setSelectedIndex(0));
    }

    private void clearRegisterFields() {
        nombreField.setText("");
        apellidoField.setText("");
        cedulaField.setText("");
        celularField.setText("");
        regEmailField.setText("");
        regPasswordField.setText("");
    }
}
