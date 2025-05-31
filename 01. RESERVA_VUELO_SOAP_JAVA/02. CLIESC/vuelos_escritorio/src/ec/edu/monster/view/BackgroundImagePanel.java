/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ec.edu.monster.view;
import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.io.IOException;

/**
 *
 * @author sebas
 */
public class BackgroundImagePanel extends JPanel{
    private Image backgroundImage;

    public BackgroundImagePanel(String imagePath) {
        try {
            backgroundImage = ImageIO.read(getClass().getResourceAsStream("/ec/edu/monster/img/" + imagePath));
        } catch (IOException | NullPointerException e) {
            System.err.println("Error loading background image: " + e.getMessage());
            backgroundImage = null;
        }
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        if (backgroundImage != null) {
            g.drawImage(backgroundImage, 0, 0, getWidth(), getHeight(), this);
        }
    }
}
