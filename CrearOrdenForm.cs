using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Proyecto.Data;

namespace Proyecto
{
    public partial class CrearOrdenForm : Form
    {
        public CrearOrdenForm()
        {
            InitializeComponent();
            LoadTechnicians();
        }

        private void LoadTechnicians()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_technician, nombre FROM Technicians ORDER BY nombre";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbTechnician.DataSource = dt;
                        cmbTechnician.DisplayMember = "nombre";
                        cmbTechnician.ValueMember = "id_technician";
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción para la orden");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO Ordenes (descripcion, fecha_inicio, id_technician, estado)
                    VALUES (@descripcion, @fecha, @idTechnician, 'Abierta')";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@idTechnician", cmbTechnician.SelectedValue);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Orden creada exitosamente");
                        this.Close();
                    }
                }
            }
        }
    }
}