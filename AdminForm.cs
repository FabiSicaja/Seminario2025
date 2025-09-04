using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Proyecto.Data;
using Proyecto_de_Seminario;

namespace Proyecto
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            LoadOrdenes();
        }

        private void LoadOrdenes()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT o.id_orden, o.descripcion, o.fecha_inicio, o.fecha_fin, 
                           t.nombre as technician, o.estado,
                           COALESCE(SUM(g.monto), 0) as total_gastos
                    FROM Ordenes o
                    LEFT JOIN Technicians t ON o.id_technician = t.id_technician
                    LEFT JOIN Gastos g ON o.id_orden = g.id_orden
                    GROUP BY o.id_orden
                    ORDER BY o.fecha_inicio DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOrdenes.DataSource = dt;
                    }
                }
            }
        }

        private void btnCrearOrden_Click(object sender, EventArgs e)
        {
            CrearOrdenForm crearOrdenForm = new CrearOrdenForm();
            crearOrdenForm.FormClosed += (s, args) => LoadOrdenes();
            crearOrdenForm.ShowDialog();
        }

        private void btnVerGastos_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una orden primero");
                return;
            }

            int idOrden = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["id_orden"].Value);
            VerGastosForm verGastosForm = new VerGastosForm(idOrden);
            verGastosForm.ShowDialog();
        }

        private void btnCerrarOrden_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una orden primero");
                return;
            }

            int idOrden = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["id_orden"].Value);
            string estado = dgvOrdenes.CurrentRow.Cells["estado"].Value.ToString();

            if (estado == "Cerrada")
            {
                MessageBox.Show("Esta orden ya está cerrada");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Ordenes SET estado = 'Cerrada', fecha_fin = @fecha WHERE id_orden = @idOrden";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@idOrden", idOrden);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Orden cerrada exitosamente");
                        LoadOrdenes();
                    }
                }
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.Clear();
            Application.Exit();
        }


    }
}