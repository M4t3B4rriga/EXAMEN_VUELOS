package ec.edu.monster.view;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.io.IOException;

public class BackgroundImagePanel extends JPanel {
    private Image backgroundImage;

    public BackgroundImagePanel(String imagePath) {
        try {
            // Cargar la imagen desde los recursos
            backgroundImage = ImageIO.read(getClass().getResource("/ec/edu/monster/img/" + imagePath));
        } catch (IOException | NullPointerException e) {
            System.err.println("Error cargando la imagen de fondo: " + e.getMessage());
            // Si falla, usar un color de fondo sólido
            setBackground(new Color(30, 144, 255)); // Azul dodger
        }
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        
        if (backgroundImage != null) {
            // Dibujar la imagen escalada para cubrir todo el panel
            g.drawImage(backgroundImage, 0, 0, getWidth(), getHeight(), this);
        }
    }
}