/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ec.edu.monster.view;
import ec.edu.monster.model.VueloClient;
import ec.edu.monster.controller.Vuelo;
import ec.edu.monster.controller.Boleto;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.text.SimpleDateFormat;
import java.util.List;
import javax.swing.JFrame;

/**
 *
 * @author sebas
 */
public class MainWindow extends JFrame{
    private final int idUsuario;
    private JTextField origenField;
    private JTextField destinoField;
    private JTextField fechaField;
    private JTextField idVueloField;
    private JTextField asientosField;
    private JTable resultTable;
    private DefaultTableModel tableModel;
    private JTabbedPane tabbedPane;

    public MainWindow(int idUsuario) {
        this.idUsuario = idUsuario;
        setTitle("Viajecitos S.A. - Menú Principal");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        
        BackgroundImagePanel backgroundPanel = new BackgroundImagePanel("menu.jpeg");
        backgroundPanel.setLayout(new BorderLayout(15, 15));
        backgroundPanel.setBorder(BorderFactory.createEmptyBorder(15, 15, 15, 15));
        
        tabbedPane = new JTabbedPane();

        // Search Flights Tab
        JPanel searchPanel = new JPanel(new BorderLayout(5, 5));
        searchPanel.setOpaque(false);
        JPanel searchInputPanel = new JPanel(new GridLayout(3, 2, 5, 5));
        searchInputPanel.setOpaque(false);
        searchInputPanel.add(new JLabel("Ciudad Origen (e.g., MEX):"));
        origenField = new JTextField();
        searchInputPanel.add(origenField);
        searchInputPanel.add(new JLabel("Ciudad Destino (e.g., CUN):"));
        destinoField = new JTextField();
        searchInputPanel.add(destinoField);
        searchInputPanel.add(new JLabel("Fecha (YYYY-MM-DD):"));
        fechaField = new JTextField();
        searchInputPanel.add(fechaField);
        JButton searchButton = new JButton("Buscar Vuelos");
        searchPanel.add(searchInputPanel, BorderLayout.NORTH);
        searchPanel.add(searchButton, BorderLayout.SOUTH);

        // Buy Tickets Tab
        JPanel buyPanel = new JPanel(new BorderLayout(5, 5));
        buyPanel.setOpaque(false);
        JPanel buyInputPanel = new JPanel(new GridLayout(2, 2, 5, 5));
        buyInputPanel.setOpaque(false);
        buyInputPanel.add(new JLabel("ID de Vuelo:"));
        idVueloField = new JTextField();
        buyInputPanel.add(idVueloField);
        buyInputPanel.add(new JLabel("Número de Asientos:"));
        asientosField = new JTextField();
        buyInputPanel.add(asientosField);
        JButton buyButton = new JButton("Comprar Boletos");
        buyPanel.add(buyInputPanel, BorderLayout.NORTH);
        buyPanel.add(buyButton, BorderLayout.SOUTH);

        // My Tickets Tab
        JPanel ticketsPanel = new JPanel(new BorderLayout(5, 5));
        ticketsPanel.setOpaque(false);
        JButton ticketsButton = new JButton("Mostrar Mis Boletos");
        ticketsPanel.add(ticketsButton, BorderLayout.NORTH);

        // All Flights Tab
        JPanel allFlightsPanel = new JPanel(new BorderLayout(5, 5));
        allFlightsPanel.setOpaque(false);
        JButton allFlightsButton = new JButton("Mostrar Todos los Vuelos");
        allFlightsPanel.add(allFlightsButton, BorderLayout.NORTH);

        // Result Table
        String[] columns = {"ID", "Origen", "Destino", "Valor", "Fecha Salida", "Asientos"};
        tableModel = new DefaultTableModel(columns, 0);
        resultTable = new JTable(tableModel);
        JScrollPane tableScrollPane = new JScrollPane(resultTable);
        
        // Create a centered panel for the table
        JPanel tablePanel = new JPanel(new BorderLayout());
        tablePanel.setOpaque(false);
        tablePanel.add(tableScrollPane, BorderLayout.CENTER);
        tablePanel.setBorder(BorderFactory.createEmptyBorder(10, 50, 10, 50)); // Add some padding

        // Logout Button
        JPanel logoutPanel = new JPanel(new FlowLayout(FlowLayout.RIGHT));
        logoutPanel.setOpaque(false);
        JButton logoutButton = new JButton("Cerrar Sesión");
        logoutPanel.add(logoutButton);

        // Add Tabs
        tabbedPane.addTab("Buscar Vuelos", searchPanel);
        tabbedPane.addTab("Comprar Boletos", buyPanel);
        tabbedPane.addTab("Mis Boletos", ticketsPanel);
        tabbedPane.addTab("Todos los Vuelos", allFlightsPanel);

        // Add components to background panel
        backgroundPanel.add(tabbedPane, BorderLayout.CENTER);
        backgroundPanel.add(tablePanel, BorderLayout.SOUTH);
        backgroundPanel.add(logoutPanel, BorderLayout.NORTH);

        add(backgroundPanel);

        // Action Listeners
        searchButton.addActionListener(e -> searchFlights());
        buyButton.addActionListener(e -> buyTickets());
        ticketsButton.addActionListener(e -> showMyTickets());
        allFlightsButton.addActionListener(e -> showAllFlights());
        logoutButton.addActionListener(e -> {
            new LoginWindow().setVisible(true);
            dispose();
        });
    }

    private void searchFlights() {
        try {
            String origen = origenField.getText();
            String destino = destinoField.getText();
            String fechaStr = fechaField.getText();
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
            java.util.Date fecha = sdf.parse(fechaStr);
            List<Vuelo> vuelos = VueloClient.buscarVuelos(origen, destino, fecha);
            updateTable(vuelos);
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Error al buscar vuelos: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void buyTickets() {
        try {
            int idVuelo = Integer.parseInt(idVueloField.getText());
            int numeroAsientos = Integer.parseInt(asientosField.getText());
            int result = VueloClient.comprarBoletos(idUsuario, idVuelo, numeroAsientos);
            JOptionPane.showMessageDialog(this, "Compra de boletos: " + (result == 1 ? "Éxito" : "Fallo"), "Resultado", JOptionPane.INFORMATION_MESSAGE);
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Error al comprar boletos: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void showMyTickets() {
        try {
            List<Boleto> boletos = VueloClient.mostrarBoletosUsuario(idUsuario);
            updateTable(boletos);
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Error al obtener boletos: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void showAllFlights() {
        try {
            List<Vuelo> vuelos = VueloClient.mostrarTodosVuelos();
            updateTable(vuelos);
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Error al obtener vuelos: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void updateTable(List<?> data) {
        tableModel.setRowCount(0);
        if (data.isEmpty()) {
            JOptionPane.showMessageDialog(this, "No se encontraron resultados.", "Información", JOptionPane.INFORMATION_MESSAGE);
            return;
        }
        if (data.get(0) instanceof Vuelo) {
            tableModel.setColumnIdentifiers(new String[]{"ID", "Origen", "Destino", "Valor", "Fecha Salida", "Asientos"});
            for (Vuelo vuelo : (List<Vuelo>) data) {
                tableModel.addRow(new Object[]{
                        vuelo.getIdVuelo(),
                        vuelo.getCiudadOrigen(),
                        vuelo.getCiudadDestino(),
                        String.format("%.2f", vuelo.getValor()),
                        vuelo.getHoraSalida().toString(),
                        vuelo.getAsientosDisponibles()
                });
            }
        } else if (data.get(0) instanceof Boleto) {
            tableModel.setColumnIdentifiers(new String[]{"ID Boleto", "ID Vuelo", "Fecha Compra", "Asiento", "Valor"});
            for (Boleto boleto : (List<Boleto>) data) {
                tableModel.addRow(new Object[]{
                        boleto.getIdBoleto(),
                        boleto.getIdVuelo(),
                        boleto.getFechaCompra().toString(),
                        boleto.getNumeroAsiento(),
                        String.format("%.2f", boleto.getValor())
                });
            }
        }
    }
}