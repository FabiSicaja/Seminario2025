using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Proyecto.Data;
using Proyecto_de_Seminario;

namespace Proyecto
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Database.InitializeDatabase();
            Database.CreateTables();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtClave.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_usuario, username, tipo, id_technician FROM Usuarios WHERE username = @username AND password = @password";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session.UserId = reader.GetInt32(0);
                            Session.Username = reader.GetString(1);
                            Session.UserType = reader.GetString(2);
                            Session.TechnicianId = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                            if (Session.UserType == "Admin")
                            {
                                AdminForm adminForm = new AdminForm();
                                adminForm.Show();
                            }
                            else
                            {
                                TechnicianForm technicianForm = new TechnicianForm();
                                technicianForm.Show();
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos");
                        }
                    }
                }
            }
        }
    }
}
