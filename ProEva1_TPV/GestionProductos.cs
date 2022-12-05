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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            if (textBox1.Text.Trim().Length > 0 || textBox2.Text.Trim().Length > 0 || textBox3.Text.Trim().Length > 0)
            {
               
                try
                {
                    MySqlCommand sda = new MySqlCommand("INSERT INTO productos (Nombre, Precio, Stock) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');", myCon);
                    sda.ExecuteReader();
                    Microsoft.VisualBasic.Interaction.MsgBox("El usuario ha sido registrado");
                    listBox1.Items.Add(textBox1.Text);
                }
                catch (Exception)
                {
                    Microsoft.VisualBasic.Interaction.MsgBox("El usuario ya ha sido registrado previamente añada uno con un nombre diferente");
                }
            
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            } 
            
            else
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Rellene todos los campos, para añadir el registro a la base de datos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            Hide();
            new Gestion(rol, cadenaConexion).Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox4.Text = "";

            foreach (object item in listBox1.SelectedItems)
            {
                System.Diagnostics.Debug.WriteLine(item);
                textBox6.Text += item.ToString() + " ";
                textBox4.Text += item.ToString() + " ";
            }
        }

        private void GestionProductos_Load_1(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM productos", myCon);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                System.Diagnostics.Debug.WriteLine(dr["Nombre"]);
                listBox1.Items.Add(dr["Nombre"]);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            MySqlCommand sda = new MySqlCommand("DELETE FROM productos WHERE Nombre='" + textBox4.Text + "';", myCon);
            sda.ExecuteReader();

            if (listBox1.SelectedItem == null)
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Seleccione un dato para eliminarlo");
            }
            else
            {

                for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
                {
                    int var = listBox1.SelectedIndices[x];
                    listBox1.Items.RemoveAt(var);

                }

                if (listBox1.Items.Count == 0)
                {
                    textBox4.Text = "";
                    textBox6.Text = "";
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            if (textBox5.Text.Trim().Length > 0 || textBox7.Text.Trim().Length > 0)
            {
                MySqlCommand sda = new MySqlCommand("UPDATE productos SET Precio = '" + textBox5.Text + "', Stock = '" + textBox7.Text + "' WHERE Nombre = '" + textBox6.Text + "'; ", myCon);
                sda.ExecuteReader();
                

                Microsoft.VisualBasic.Interaction.MsgBox("El usuario ha sido actualizado");
            }
            else
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Rellene todos los campos, para modificar el registro a la base de datos");
            }

            textBox5.Text = "";
            textBox7.Text = "";
        }
    }
}
