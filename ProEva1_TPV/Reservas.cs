using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProEva1_TPV
{
    public partial class Reservas : Form
    {
        string rol;
        string cadenaConexion;
        string SelectItem, SelectItemCart;
        
        ArrayList Listaproductos = new ArrayList();
        

        public Reservas(string rol, string cadenaConexion)
        {
            this.rol = rol;
            this.cadenaConexion = cadenaConexion;
            InitializeComponent();
        }

        private void anyadir(object sender, EventArgs e)
        {
            if(SelectItem != null)
            {
                MySqlConnection myCon = new MySqlConnection(cadenaConexion);
                myCon.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM productos WHERE Nombre = '"+ SelectItem + "'", myCon);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    int stock = (int)dr["Stock"];
                    string nombre = (string)dr["Nombre"];
                    double precio = (double)dr["Precio"];

                    Producto producto = new Producto(nombre, stock, precio);
                    Listaproductos.Add(producto);

                    System.Diagnostics.Debug.WriteLine(dr["Stock"]);
                    
                    if (stock > 0)
                    {

                        MySqlCommand sda1 = new MySqlCommand("UPDATE productos SET Stock = '" + 1 + "' WHERE Nombre = '" + SelectItem + "'; ", myCon);
                        sda1.ExecuteReader();
                        if (!listBox2.Items.Contains(dr["Nombre"]))
                        {
                            listBox2.Items.Add(dr["Nombre"]);
                        }
                    }
                    else
                    {
                        for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
                        {
                            int var = listBox1.SelectedIndices[x];
                            listBox1.Items.RemoveAt(var);
                        }
                    }

                }
            }
            else
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Seleccione un producto para añadirlo a la reserva");
            }
        }

        private void eliminar(object sender, EventArgs e)
        {
            if (SelectItemCart != null)
            {
                MySqlConnection myCon = new MySqlConnection(cadenaConexion);
                myCon.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM productos WHERE Nombre = '" + SelectItemCart + "'", myCon);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    System.Diagnostics.Debug.WriteLine(dr["Stock"]);
                    int stock = (int)dr["Stock"];
                    
                    int sum = stock + 1;
                    
                    
                    MySqlCommand sda1 = new MySqlCommand("UPDATE productos SET Stock = '" + sum + "' WHERE Nombre = '" + SelectItemCart + "'; ", myCon);
                    sda1.ExecuteReader();

                    if (!listBox1.Items.Contains(dr["Nombre"]))
                    {
                        listBox1.Items.Add(dr["Nombre"]);
                    }
                }
            }
            else
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Seleccione un producto para añadirlo a la reserva");
            }
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
            foreach (object item in listBox1.SelectedItems)
            {
                System.Diagnostics.Debug.WriteLine(item);
                SelectItem = (string)item;
            }
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM productos", myCon);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                System.Diagnostics.Debug.WriteLine(dr["Stock"]);
                int stock = (int)dr["Stock"];

                

                if (stock > 0)
                {
                    listBox1.Items.Add(dr["Nombre"]);
                }
                
            }
        }

        private void productosEnCesta(object sender, EventArgs e)
        {
            foreach (object item in listBox1.SelectedItems)
            {
                System.Diagnostics.Debug.WriteLine(item);
                SelectItemCart = (string)item;
            }
        }
    }
}
