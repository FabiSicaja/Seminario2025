using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Proyecto.Data;
using Proyecto_de_Seminario;

namespace Proyecto
{
    public partial class TechnicianForm : Form
    {
        public TechnicianForm()
        {
            InitializeComponent();
            LoadOrdenesAsignadas();
        }

        private void LoadOrdenesAsignadas()
        {
            if (!Session.TechnicianId.HasValue) return;

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT o.id_orden, o.descripcion, o.fecha_inicio, o.fecha_fin, o.estado,
                           COALESCE(SUM(g.monto), 0) as total_gastos
                    FROM Ordenes o
                    LEFT JOIN Gastos g ON o.id_orden = g.id_orden
                    WHERE o.id_technician = @idTechnician
                    GROUP BY o.id_orden
                    ORDER BY o.fecha_inicio DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idTechnician", Session.TechnicianId.Value);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOrdenes.DataSource = dt;
                    }
                }
            }
        }

        private void btnIngresarGasto_Click(object sender, EventArgs e)
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
                MessageBox.Show("No puede agregar gastos a una orden cerrada");
                return;
            }

            IngresarGastoForm ingresarGastoForm = new IngresarGastoForm(idOrden);
            ingresarGastoForm.FormClosed += (s, args) => LoadOrdenesAsignadas();
            ingresarGastoForm.ShowDialog();
        }

        private void TechnicianForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.Clear();
            Application.Exit();
        }
    }
}