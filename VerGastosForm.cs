using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Proyecto.Data;

namespace Proyecto
{
    public partial class VerGastosForm : Form  // Asegúrate de que herede de Form
    {
        private int _idOrden;

        public VerGastosForm(int idOrden)
        {
            InitializeComponent();  // Esto debe estar presente
            _idOrden = idOrden;
            lblOrden.Text = $"Gastos de la Orden: {idOrden}";
            LoadGastos();
        }

        private void LoadGastos()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT g.descripcion, g.monto, g.fecha
                    FROM Gastos g
                    WHERE g.id_orden = @idOrden
                    ORDER BY g.fecha DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", _idOrden);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvGastos.DataSource = dt;
                    }
                }

                // Calcular total
                string totalQuery = "SELECT COALESCE(SUM(monto), 0) FROM Gastos WHERE id_orden = @idOrden";
                using (var cmd = new SQLiteCommand(totalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", _idOrden);
                    decimal total = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblTotal.Text = $"Total: {total:C}";
                }
            }
        }

        // Agregar este método si el diseñador tiene el evento Load
        private void VerGastosForm_Load(object sender, EventArgs e)
        {
            // Código adicional al cargar el formulario si es necesario
        }
    }
}