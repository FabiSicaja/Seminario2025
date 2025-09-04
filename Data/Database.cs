using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using File = System.IO.File;

namespace Proyecto.Data
{
    public class Database
    {
        private static string dbFile = "Proyecto.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void InitializeDatabase()
        {

            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                Console.WriteLine("Base de datos creada: Proyecto.db");
            }
        }

        public static void CreateTables()
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                // Tabla Technicians
                string createTechniciansTable = @"
                    CREATE TABLE IF NOT EXISTS Technicians (
                        id_technician INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT NOT NULL,
                        telefono TEXT
                    );";

                // Tabla Ordenes
                string createOrdenesTable = @"
                    CREATE TABLE IF NOT EXISTS Ordenes (
                        id_orden INTEGER PRIMARY KEY AUTOINCREMENT,
                        descripcion TEXT NOT NULL,
                        fecha_inicio DATE NOT NULL,
                        fecha_fin DATE,
                        id_technician INTEGER,
                        estado TEXT CHECK(estado IN ('Abierta','En Proceso','Cerrada')) NOT NULL DEFAULT 'Abierta',
                        FOREIGN KEY (id_technician) REFERENCES Technicians(id_technician)
                    );";

                // Tabla Gastos
                string createGastosTable = @"
                    CREATE TABLE IF NOT EXISTS Gastos (
                        id_gasto INTEGER PRIMARY KEY AUTOINCREMENT,
                        id_orden INTEGER,
                        descripcion TEXT NOT NULL,
                        monto REAL NOT NULL,
                        fecha DATE NOT NULL,
                        FOREIGN KEY (id_orden) REFERENCES Ordenes(id_orden)
                    );";

                // Tabla Usuarios
                string createUsuariosTable = @"
                    CREATE TABLE IF NOT EXISTS Usuarios (
                        id_usuario INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT NOT NULL UNIQUE,
                        password TEXT NOT NULL,
                        tipo TEXT CHECK(tipo IN ('Admin','Technician')) NOT NULL,
                        id_technician INTEGER NULL,
                        FOREIGN KEY (id_technician) REFERENCES Technicians(id_technician)
                    );";

                using (var cmd = new SQLiteCommand(createTechniciansTable, conn))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand(createOrdenesTable, conn))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand(createGastosTable, conn))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand(createUsuariosTable, conn))
                    cmd.ExecuteNonQuery();

                InsertSampleData(conn);
            }
        }

        private static void InsertSampleData(SQLiteConnection conn)
        {
            string checkData = "SELECT COUNT(*) FROM Usuarios";
            using (var cmd = new SQLiteCommand(checkData, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0) return;
            }

            // Insertar technicians de ejemplo
            string insertTechnicians = @"
                INSERT INTO Technicians (nombre, telefono) VALUES 
                ('Juan Pérez', '1234-5678'),
                ('María García', '8765-4321'),
                ('Carlos López', '5555-1234');";

            // Insertar usuarios de ejemplo
            string insertUsuarios = @"
                INSERT INTO Usuarios (username, password, tipo, id_technician) VALUES 
                ('admin', '123', 'Admin', NULL),
                ('juan', '123', 'Technician', 1),
                ('maria', '123', 'Technician', 2),
                ('carlos', '123', 'Technician', 3);";

            using (var cmd = new SQLiteCommand(insertTechnicians, conn))
                cmd.ExecuteNonQuery();

            using (var cmd = new SQLiteCommand(insertUsuarios, conn))
                cmd.ExecuteNonQuery();
        }
    }
}