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
    public partial class GestionProductos : Form
    {
        string rol;
        string cadenaConexion;


        public GestionProductos(string rol, string cadenaConexion)
        {
            this.rol = rol;
            InitializeComponent();
            this.cadenaConexion = cadenaConexion;
        }

        private void GestionProductos_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            Hide();
            new Gestion(rol, cadenaConexion).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
