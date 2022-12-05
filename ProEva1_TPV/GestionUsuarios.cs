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
    public partial class GestionUsuarios : Form
    {
        string rol;
        string cadenaConexion;


        public GestionUsuarios(string rol, string cadenaConexion)
        {
            this.rol = rol;
            InitializeComponent();
            this.cadenaConexion = cadenaConexion;
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM login", myCon);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                System.Diagnostics.Debug.WriteLine(dr["Usuario"]);
                listBox1.Items.Add(dr["Usuario"]);
            }

        }

        private void atras(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            Hide();
            new Gestion(rol, cadenaConexion).Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox4.Text = "";

            foreach (object item in listBox1.SelectedItems)
            {
                System.Diagnostics.Debug.WriteLine(item);
                textBox5.Text += item.ToString() + " ";
                textBox4.Text += item.ToString() + " ";
            }
        }

        private void eliminar(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            MySqlCommand sda = new MySqlCommand("DELETE FROM login WHERE Usuario='" + textBox4.Text + "';", myCon);
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
                    textBox5.Text = "";
                }
            }
        }

        private void anyadir(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            if (textBox1.Text.Trim().Length > 0 || textBox2.Text.Trim().Length > 0)
            {
                if (checkBox1.Checked)
                {
                    try
                    {
                        MySqlCommand sda = new MySqlCommand("INSERT INTO login (Usuario, Contraseña, Admin) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + 1 + "');", myCon);
                        sda.ExecuteReader();
                        Microsoft.VisualBasic.Interaction.MsgBox("El usuario ha sido registrado");
                        listBox1.Items.Add(textBox1.Text);
                    }
                    catch (Exception)
                    {
                        Microsoft.VisualBasic.Interaction.MsgBox("El usuario ya ha sido registrado previamente añada uno con un nombre diferente");
                    }
                }
                else
                {
                    try
                    {
                        MySqlCommand sda = new MySqlCommand("INSERT INTO login (Usuario, Contraseña, Admin) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + 0 + "');", myCon);
                        sda.ExecuteReader();
                        Microsoft.VisualBasic.Interaction.MsgBox("El usuario ha sido registrado");
                        listBox1.Items.Add(textBox1.Text);
                    }
                    catch (Exception)
                    {
                        Microsoft.VisualBasic.Interaction.MsgBox("El usuario ya ha sido registrado previamente añada uno con un nombre diferente");
                    }
                }
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
            }
            else
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Rellene todos los campos, para añadir el registro a la base de datos");
            }
        }

        private void modificar(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            if (textBox6.Text.Trim().Length > 0)
            {
                if (checkBox2.Checked)
                {
                    MySqlCommand sda = new MySqlCommand("UPDATE login SET Contraseña = '" + textBox6.Text + "', Admin = '" + 1 + "' WHERE Usuario = '" + textBox5.Text + "'; ", myCon);
                    sda.ExecuteReader();
                }
                else
                {
                    MySqlCommand sda = new MySqlCommand("UPDATE login SET Contraseña = '" + textBox6.Text + "', Admin = '" + 0 + "' WHERE Usuario = '" + textBox5.Text + "'; ", myCon);
                    sda.ExecuteReader();
                }

                Microsoft.VisualBasic.Interaction.MsgBox("El usuario ha sido actualizado");
            }
            else
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Rellene todos los campos, para modificar el registro a la base de datos");
            }

            textBox6.Text = "";
            checkBox2.Checked = false;
        }
    }
}
