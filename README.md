# Seminario2025
Aplicación de Escritorio

Este es el prompt que ingresé a DeepSeek:
Estoy iniciando mi proyecto de seminario de graduación, es sobre realizar un proyecto de software para una empresa que por seguridad llamaré "Proyecto S.A." estoy trabajando con mi equipo de 3 integrantes más. El dueño de la empresa pidió tener un sistema que le ayude a crear ordenes de servicios, a cada orden se le asignará una persona técnico asignado del servicio, cada ejecutor ingresará sus gastos, los cuales recibirá el cobrador del servicio, el cobrador va a poder ver un consolidado de los gastos y dar cierre a la orden cuando el servicio esté completo. Podrá tener un reporte del consolidado y pasar el gasto al departamento de cobros. El dueño no quiere gastos recurrentes por lo que no optamos por una aplicación web ya que representa gastos en certificados, dominio, etc. Además quiere un software muy personalizado sólo para su empresa. Por lo tanto, optamos por una aplicación de escritorio, pero no sabemos nada de crear aplicaciones de escritorio desde 0. De momento tengo una estructura inicial usando C# con .NET (WinForms/WPF) y DB Browser para base de datos SQL Lite. 
Necesito que me ayudes a generar el código de cada ventana para que interactúen entre sí y pueda darse el flujo desde que se logea un usuario técnico(también llamado ejecutor) o un usuario admin, hasta la creación de la orden, ingreso de gastos, hasta cierre de una orden, en fin, todo el flujo de trabajo. 

Este es el script con que se crearon las tablas principales:
-- 1. Crear tablas
CREATE TABLE IF NOT EXISTS Ejecutores (
    id_ejecutor INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL,
    telefono TEXT
);

CREATE TABLE IF NOT EXISTS Ordenes (
    id_orden INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE,
    id_ejecutor INTEGER,
    estado TEXT CHECK(estado IN ('Abierta','En Proceso','Cerrada')) NOT NULL DEFAULT 'Abierta',
    FOREIGN KEY (id_ejecutor) REFERENCES Ejecutores(id_ejecutor)
);

CREATE TABLE IF NOT EXISTS Gastos (
    id_gasto INTEGER PRIMARY KEY AUTOINCREMENT,
    id_orden INTEGER,
    descripcion TEXT NOT NULL,
    monto REAL NOT NULL,
    fecha DATE NOT NULL,
    FOREIGN KEY (id_orden) REFERENCES Ordenes(id_orden)
);

CREATE TABLE IF NOT EXISTS Usuarios (
    id_usuario INTEGER PRIMARY KEY AUTOINCREMENT,
    username TEXT NOT NULL UNIQUE,
    password TEXT NOT NULL,
    tipo TEXT CHECK(tipo IN ('Admin','Ejecutor')) NOT NULL,
    id_ejecutor INTEGER NULL,
    FOREIGN KEY (id_ejecutor) REFERENCES Ejecutores(id_ejecutor)
);

-- 2. Insertar datos de ejecutores
INSERT INTO Ejecutores (nombre, telefono) VALUES 
('Juan Pérez', '1234-5678'),
('María García', '8765-4321'),
('Carlos López', '5555-1234'),
('Ana Rodríguez', '3333-9999'),
('Luis Martínez', '1111-2222');

-- 3. Insertar usuarios (password: '123' en texto plano para demo)
INSERT INTO Usuarios (username, password, tipo, id_ejecutor) VALUES 
('admin', '123', 'Admin', NULL),
('juan', '123', 'Ejecutor', 1),
('maria', '123', 'Ejecutor', 2),
('carlos', '123', 'Ejecutor', 3),
('ana', '123', 'Ejecutor', 4),
('luis', '123', 'Ejecutor', 5);

-- 4. Insertar órdenes de ejemplo
INSERT INTO Ordenes (descripcion, fecha_inicio, id_ejecutor, estado) VALUES 
('Mantenimiento preventivo sistema HVAC', '2024-01-15', 1, 'Abierta'),
('Reparación de equipo de refrigeración', '2024-01-16', 2, 'En Proceso'),
('Instalación de nuevo sistema eléctrico', '2024-01-10', 3, 'Cerrada'),
('Limpieza de ductos de aire acondicionado', '2024-01-18', 1, 'Abierta'),
('Calibración de sensores de temperatura', '2024-01-17', 4, 'En Proceso');

-- 5. Insertar gastos de ejemplo
INSERT INTO Gastos (id_orden, descripcion, monto, fecha) VALUES 
(1, 'Refrigerante R410A', 150.75, '2024-01-15'),
(1, 'Filtros de aire', 45.50, '2024-01-15'),
(1, 'Transporte', 25.00, '2024-01-15'),
(2, 'Compresor nuevo', 320.00, '2024-01-16'),
(2, 'Mano de obra', 120.00, '2024-01-16'),
(3, 'Cableado eléctrico', 185.30, '2024-01-10'),
(3, 'Interruptores y breakers', 95.45, '2024-01-11'),
(3, 'Transporte', 30.00, '2024-01-12'),
(4, 'Productos de limpieza', 35.80, '2024-01-18'),
(5, 'Kit de calibración', 78.90, '2024-01-17'),
(5, 'Transporte', 20.00, '2024-01-17');

-- 6. Script para verificar que los datos se insertaron correctamente
SELECT '=== EJECUTORES ===' as Info;
SELECT * FROM Ejecutores;

SELECT '=== USUARIOS ===' as Info;
SELECT * FROM Usuarios;

SELECT '=== ÓRDENES ===' as Info;
SELECT o.*, e.nombre as ejecutor 
FROM Ordenes o 
LEFT JOIN Ejecutores e ON o.id_ejecutor = e.id_ejecutor;

SELECT '=== GASTOS ===' as Info;
SELECT g.*, o.descripcion as orden 
FROM Gastos g 
JOIN Ordenes o ON g.id_orden = o.id_orden;

SELECT '=== TOTAL GASTOS POR ORDEN ===' as Info;
SELECT o.id_orden, o.descripcion, 
       COUNT(g.id_gasto) as cantidad_gastos, 
       SUM(g.monto) as total_gastos
FROM Ordenes o 
LEFT JOIN Gastos g ON o.id_orden = g.id_orden
GROUP BY o.id_orden;
