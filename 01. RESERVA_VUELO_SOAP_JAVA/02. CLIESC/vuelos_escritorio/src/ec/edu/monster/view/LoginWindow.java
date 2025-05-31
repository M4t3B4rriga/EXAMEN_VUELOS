package ec.edu.monster.view;

import ec.edu.monster.model.VueloClient;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class LoginWindow extends JFrame {
    private JTextField emailField;
    private JPasswordField passwordField;
    private JTextField nombreField;
    private JTextField apellidoField;
    private JTextField cedulaField;
    private JTextField celularField;
    private JTextField regEmailField;
    private JPasswordField regPasswordField;
    private JTabbedPane tabbedPane;

    public LoginWindow() {
        setTitle("Viajecitos S.A. - Bienvenida");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        
        // Panel principal con imagen de fondo
        BackgroundImagePanel mainPanel = new BackgroundImagePanel("login.jpg");
        mainPanel.setLayout(new BorderLayout());
        
        // Panel contenedor transparente
        JPanel contentPanel = new JPanel();
        contentPanel.setOpaque(false);
        contentPanel.setLayout(new BorderLayout());
        
        // Crear pestañas
        tabbedPane = new JTabbedPane();
        tabbedPane.setOpaque(false);
        
        // Panel de Login
        JPanel loginPanel = createLoginPanel();
        tabbedPane.addTab("Iniciar Sesión", loginPanel);
        
        // Panel de Registro
        JPanel registerPanel = createRegisterPanel();
        tabbedPane.addTab("Registrarse", registerPanel);
        
        // Centrar el tabbedPane
        JPanel centerPanel = new JPanel(new GridBagLayout());
        centerPanel.setOpaque(false);
        centerPanel.setBorder(BorderFactory.createEmptyBorder(50, 50, 50, 50));
        centerPanel.add(tabbedPane);
        
        contentPanel.add(centerPanel, BorderLayout.CENTER);
        mainPanel.add(contentPanel, BorderLayout.CENTER);
        
        add(mainPanel);
    }

    private JPanel createLoginPanel() {
        JPanel panel = new JPanel(new GridBagLayout());
        panel.setOpaque(false);
        panel.setBorder(BorderFactory.createEmptyBorder(20, 20, 20, 20));
        
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(10, 10, 10, 10);
        gbc.anchor = GridBagConstraints.WEST;
        
        // Título
        JLabel titleLabel = new JLabel("Iniciar Sesión");
        titleLabel.setFont(new Font("Arial", Font.BOLD, 18));
        titleLabel.setForeground(Color.WHITE);
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridwidth = 2;
        panel.add(titleLabel, gbc);
        
        // Separador
        JSeparator separator = new JSeparator();
        separator.setForeground(Color.WHITE);
        gbc.gridy = 1;
        panel.add(separator, gbc);
        
        // Email
        JLabel emailLabel = new JLabel("Email:");
        emailLabel.setForeground(Color.WHITE);
        gbc.gridy = 2;
        gbc.gridwidth = 1;
        panel.add(emailLabel, gbc);
        
        emailField = new JTextField(20);
        gbc.gridx = 1;
        panel.add(emailField, gbc);
        
        // Contraseña
        JLabel passLabel = new JLabel("Contraseña:");
        passLabel.setForeground(Color.WHITE);
        gbc.gridx = 0;
        gbc.gridy = 3;
        panel.add(passLabel, gbc);
        
        passwordField = new JPasswordField(20);
        gbc.gridx = 1;
        panel.add(passwordField, gbc);
        
        // Separador
        gbc.gridx = 0;
        gbc.gridy = 4;
        gbc.gridwidth = 2;
        panel.add(new JSeparator(), gbc);
        
        // Botones
        JButton loginButton = new JButton("Iniciar Sesión");
        gbc.gridy = 5;
        gbc.gridwidth = 1;
        gbc.fill = GridBagConstraints.HORIZONTAL;
        panel.add(loginButton, gbc);
        
        JButton exitButton = new JButton("Salir");
        gbc.gridx = 1;
        panel.add(exitButton, gbc);
        
        // Configurar acciones
        loginButton.addActionListener(e -> {
            String email = emailField.getText();
            String password = new String(passwordField.getPassword());
            
            if (VueloClient.login(email, password)) {
                int idUsuario = VueloClient.obtenerIdUsuarioPorEmail(email);
                if (idUsuario != -1) {
                    MainWindow mainWindow = new MainWindow(idUsuario);
                    mainWindow.setVisible(true);
                    dispose();
                } else {
                    JOptionPane.showMessageDialog(this, 
                        "Error: No se pudo obtener ID de usuario", 
                        "Error", JOptionPane.ERROR_MESSAGE);
                }
            } else {
                JOptionPane.showMessageDialog(this, 
                    "Email o contraseña incorrectos", 
                    "Error", JOptionPane.ERROR_MESSAGE);
            }
        });
        
        exitButton.addActionListener(e -> System.exit(0));
        
        return panel;
    }

    private JPanel createRegisterPanel() {
        JPanel panel = new JPanel(new GridBagLayout());
        panel.setOpaque(false);
        panel.setBorder(BorderFactory.createEmptyBorder(20, 20, 20, 20));
        
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(10, 10, 10, 10);
        gbc.anchor = GridBagConstraints.WEST;
        
        // Título
        JLabel titleLabel = new JLabel("Registro de Usuario");
        titleLabel.setFont(new Font("Arial", Font.BOLD, 18));
        titleLabel.setForeground(Color.WHITE);
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridwidth = 2;
        panel.add(titleLabel, gbc);
        
        // Separador
        JSeparator separator = new JSeparator();
        separator.setForeground(Color.WHITE);
        gbc.gridy = 1;
        panel.add(separator, gbc);
        
        // Campos de registro
        String[] labels = {"Nombre:", "Apellido:", "Cédula:", "Celular:", "Email:", "Contraseña:"};
        JTextField[] fields = {
            nombreField = new JTextField(20),
            apellidoField = new JTextField(20),
            cedulaField = new JTextField(20),
            celularField = new JTextField(20),
            regEmailField = new JTextField(20),
        };
        regPasswordField = new JPasswordField(20);
        
        for (int i = 0; i < labels.length; i++) {
            JLabel label = new JLabel(labels[i]);
            label.setForeground(Color.WHITE);
            gbc.gridx = 0;
            gbc.gridy = i + 2;
            gbc.gridwidth = 1;
            panel.add(label, gbc);
            
            gbc.gridx = 1;
            if (i == labels.length - 1) {
                panel.add(regPasswordField, gbc);
            } else {
                panel.add(fields[i], gbc);
            }
        }
        
        // Separador
        gbc.gridx = 0;
        gbc.gridy = labels.length + 2;
        gbc.gridwidth = 2;
        panel.add(new JSeparator(), gbc);
        
        // Botones
        JButton registerButton = new JButton("Registrarse");
        gbc.gridy = labels.length + 3;
        gbc.gridwidth = 1;
        gbc.fill = GridBagConstraints.HORIZONTAL;
        panel.add(registerButton, gbc);
        
        JButton backButton = new JButton("Volver");
        gbc.gridx = 1;
        panel.add(backButton, gbc);
        
        // Configurar acciones
        registerButton.addActionListener(e -> {
            String nombre = nombreField.getText();
            String apellido = apellidoField.getText();
            String cedula = cedulaField.getText();
            String celular = celularField.getText();
            String email = regEmailField.getText();
            String password = new String(regPasswordField.getPassword());
            
            try {
                int result = VueloClient.registrarUsuario(nombre, apellido, cedula, celular, email, password);
                if (result == 1) {
                    JOptionPane.showMessageDialog(this, 
                        "Registro exitoso! Ahora puede iniciar sesión", 
                        "Éxito", JOptionPane.INFORMATION_MESSAGE);
                    tabbedPane.setSelectedIndex(0); // Cambiar a pestaña de login
                    clearRegisterFields();
                } else {
                    JOptionPane.showMessageDialog(this, 
                        "Error al registrar usuario", 
                        "Error", JOptionPane.ERROR_MESSAGE);
                }
            } catch (Exception ex) {
                JOptionPane.showMessageDialog(this, 
                    "Error: " + ex.getMessage(), 
                    "Error", JOptionPane.ERROR_MESSAGE);
            }
        });
        
        backButton.addActionListener(e -> tabbedPane.setSelectedIndex(0));
        
        return panel;
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