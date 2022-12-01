using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProEva1_TPV
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                string server = "localhost";
                string database = "TPV";
                string user = "root";
                string pwd = "admin";
                string cadenaConexion = "server=" + server + ";database=" + database + ";" + "Uid=" + user + ";pwd=" + pwd + ";";
                MySqlConnection myCon = new MySqlConnection(cadenaConexion);
                myCon.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT COUNT(*) FROM login WHERE Usuario='" + textBox_usuario.Text + "' AND Contraseña='" + textBox_contraseña.Text + "'", myCon);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    MySqlDataAdapter adminQuery = new MySqlDataAdapter("SELECT * FROM login WHERE Usuario='" + textBox_usuario.Text + "' AND Contraseña='" + textBox_contraseña.Text + "'", myCon);
                    DataTable dt2 = new DataTable();
                    adminQuery.Fill(dt2);
                    string rol = dt2.Rows[0][2].ToString();

                    System.Diagnostics.Debug.WriteLine(rol);

                    Hide();
                    new Gestion(rol, cadenaConexion).Show();
                }
                else
                {
                    lblResultado.Text = "Usuario o contraseña erronea";
                }
            }
            catch (Exception error)
            {
                lblResultado.Text = "Error de conexion " + error;
            }
        }
    }
}
