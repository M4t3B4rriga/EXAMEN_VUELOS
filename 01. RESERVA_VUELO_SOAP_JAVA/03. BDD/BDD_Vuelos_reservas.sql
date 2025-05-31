-- Crear la base de datos
CREATE DATABASE viajecitos_sa;
USE viajecitos_sa;

-- Crear tabla Vuelos
CREATE TABLE Vuelos (
    id_vuelo INT AUTO_INCREMENT PRIMARY KEY,
    ciudad_origen VARCHAR(3) NOT NULL,
    ciudad_destino VARCHAR(3) NOT NULL,
    valor DECIMAL(7,2) NOT NULL,
    hora_salida DATETIME NOT NULL,
    asientos_disponibles INT NOT NULL DEFAULT 100
);

-- Crear tabla Usuarios (actualizada)
CREATE TABLE Usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    apellido_usuario VARCHAR(50) NOT NULL,
    cedula VARCHAR(20) NOT NULL UNIQUE,
    celular VARCHAR(15) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contrasena VARCHAR(255) NOT NULL
    );

-- Crear tabla Boletos
CREATE TABLE Boletos (
    id_boleto INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_vuelo INT NOT NULL,
    fecha_compra DATETIME NOT NULL,
    numero_asiento VARCHAR(10) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
    FOREIGN KEY (id_vuelo) REFERENCES Vuelos(id_vuelo)
);

-- Crear tabla Compras
CREATE TABLE Compras (
    id_compra INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_boleto INT NOT NULL,
    fecha_compra DATETIME NOT NULL,
    monto_total DECIMAL(7,2) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
    FOREIGN KEY (id_boleto) REFERENCES Boletos(id_boleto)
);

-- Insertar datos de prueba para Vuelos (6 registros)
INSERT INTO Vuelos (ciudad_origen, ciudad_destino, valor, hora_salida, asientos_disponibles) VALUES
('MEX', 'GDL', 1500.50, '2025-06-01 08:00:00', 100),
('MEX', 'CUN', 2500.75, '2025-06-01 10:30:00', 100),
('GDL', 'CUN', 1800.00, '2025-06-01 12:00:00', 100),
('CUN', 'MEX', 2300.25, '2025-06-02 09:00:00', 100),
('GDL', 'MTY', 1700.30, '2025-06-02 14:00:00', 100),
('MTY', 'MEX', 1900.60, '2025-06-03 16:00:00', 100);

-- Insertar datos de prueba para Usuarios
INSERT INTO Usuarios (nombre_usuario, apellido_usuario, cedula, celular, email, contrasena) VALUES
('juanperez', 'Pérez García', '1234567890', '5551234567', 'juan.perez@email.com', '$2a$10$XUR8t./.k7B7Z1Jq0X4W3e2J8Qz0t1p8v7f9Z1x2y3z4w5v6u7t8'),
('mariag', 'Gómez López', '0987654321', '5559876543', 'maria.gomez@email.com', '$2a$10$YUR9t./.k8B8Z2Jq1X5W4e3J9Qz1t2p9v8f0Z2x3y4z5w6v7u8t9'),
('MONSTER', 'MONSTER', '0996354784', '1726534263', 'monster9@espe.edu.ec', 'MONSTER');

INSERT INTO Usuarios (nombre_usuario, apellido_usuario, cedula, celular, email, contrasena) VALUES
('MONSTER', 'MONSTER', '0996354784', '1726534263', 'monster9@espe.edu.ec', 'MONSTER');
-- Insertar datos de prueba para Boletos
INSERT INTO Boletos (id_usuario, id_vuelo, fecha_compra, numero_asiento) VALUES
(1, 1, '2025-05-28 10:00:00', 'A1'),
(1, 2, '2025-05-28 10:00:00', 'B3'),
(2, 3, '2025-05-28 11:00:00', 'C2');

-- Actualizar asientos_disponibles
UPDATE Vuelos SET asientos_disponibles = asientos_disponibles - 1 WHERE id_vuelo IN (1, 2, 3);

-- Insertar datos de prueba para Compras
INSERT INTO Compras (id_usuario, id_boleto, fecha_compra, monto_total) VALUES
(1, 1, '2025-05-28 10:05:00', 1500.50),
(1, 2, '2025-05-28 10:05:00', 2500.75),
(2, 3, '2025-05-28 11:05:00', 1800);