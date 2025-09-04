using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Proyecto.Data;

namespace Proyecto
{
    public partial class IngresarGastoForm : Form
    {
        private int _idOrden;

        public IngresarGastoForm(int idOrden)
        {
            InitializeComponent();
            _idOrden = idOrden;
            lblOrden.Text = $"Orden: {idOrden}";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción para el gasto");
                return;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO Gastos (id_orden, descripcion, monto, fecha)
                    VALUES (@idOrden, @descripcion, @monto, @fecha)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrden", _idOrden);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Gasto registrado exitosamente");
                        this.Close();
                    }
                }
            }
        }
    }
}