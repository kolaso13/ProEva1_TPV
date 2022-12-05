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
    public partial class Reservas : Form
    {
        string rol;
        string cadenaConexion;

        public Reservas(string rol, string cadenaConexion)
        {
            this.rol = rol;
            this.cadenaConexion = cadenaConexion;
            InitializeComponent();
        }

        private void anyadir(object sender, EventArgs e)
        {

        }

        private void eliminar(object sender, EventArgs e)
        {

        }

        private void imprimir(object sender, EventArgs e)
        {

        }

        private void atras(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            Hide();
            new Gestion(rol, cadenaConexion).Show();
        }

        private void productosDisponibles(object sender, EventArgs e)
        {

        }
    }
}
