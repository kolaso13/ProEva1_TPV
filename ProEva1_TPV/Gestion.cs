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
    public partial class Gestion : Form
    {
        string rol;
        string cadenaConexion;
        public Gestion(string rol, string cadenaConexion)
        {
            this.rol = rol;

            InitializeComponent();
            this.cadenaConexion = cadenaConexion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "TPV";
            string user = "root";
            string pwd = "admin";
            string cadenaConexion = "server=" + server + ";database=" + database + ";" + "Uid=" + user + ";pwd=" + pwd + ";";
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();
            Hide();
            new GestionUsuarios(rol, cadenaConexion).Show();
        }

        private void Gestion_Load(object sender, EventArgs e)
        {
            if (!rol.Equals("1"))
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();
            Hide();
            new GestionProductos(rol, cadenaConexion).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new InicioSesion().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();
            Hide();
            new Reservas(rol, cadenaConexion).Show();
        }
    }
}
