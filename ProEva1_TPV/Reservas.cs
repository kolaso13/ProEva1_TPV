using iTextSharp.text;
using iTextSharp.text.pdf;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Document = iTextSharp.text.Document;

namespace ProEva1_TPV
{
    public partial class Reservas : Form
    {
        string rol;
        string cadenaConexion;
        string SelectItem, SelectItemCart;
        ArrayList Cesta = new ArrayList();
        

        public Reservas(string rol, string cadenaConexion)
        {
            this.rol = rol;
            this.cadenaConexion = cadenaConexion;
            InitializeComponent();
        }

        private void anyadir(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();

            if (SelectItem != null)
            {
               foreach(Producto p in Cesta)
               {
                    if(SelectItem == p.getNombre() && p.getCantidadTotl()!=0)
                    {
                        listBox2.Items.Add(p.getNombre());
                        p.setCantidad(p.getCantidad()+1);
                        p.setCantidadTotl(p.getCantidadTotl() - 1);
                    }
                }
                listBox1.Items.Clear();
                foreach (Producto p in Cesta)
                {
                    if (p.getCantidadTotl() != 0)
                    {
                        listBox1.Items.Add(p.getNombre());
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
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();
            if (SelectItemCart != null)
            {
                foreach (Producto p in Cesta)
                {
                    if(SelectItemCart == p.getNombre() && p.getCantidad() != 0)
                    {
                        if (!listBox1.Items.Contains(SelectItemCart))
                        {
                            listBox1.Items.Add(p.getNombre());
                        }
                        p.setCantidad(p.getCantidad() - 1);
                        p.setCantidadTotl(p.getCantidadTotl() + 1);
                        listBox2.Items.Remove(SelectItemCart);
                    }
                }
            }
            else
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Seleccione un producto para eliminarlo de la reserva");
            }
        }

        private void imprimir(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection(cadenaConexion);
            foreach (Producto p in Cesta)
            {
                myCon.Open();
                MySqlCommand sda = new MySqlCommand("UPDATE productos SET Stock = '" + p.getCantidadTotl() + "' WHERE Nombre = '" + p.getNombre() + "'; ", myCon);
                sda.ExecuteReader();
                myCon.Close();
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ticket.pdf";

            Document document = new Document();
            FileStream fs = File.Create(path);
            PdfWriter.GetInstance(document, fs);
            document.Open();
            double total = 0;
            foreach (Producto p in Cesta)
            {
                if(p.getCantidad() != 0)
                {
                    document.Add(new Paragraph(p.getNombre() + " " + p.getCantidad() + " " + p.getPrecio()+ "€"));
                    total +=  p.getCantidad() * p.getPrecio();
                }
                
            }
            
            document.Add(new Paragraph("Total: "+ total));

            document.Close();

            Hide();
            new Gestion(rol, cadenaConexion).Show();
        }

        private void atras(object sender, EventArgs e)
        {
            Hide();
            new Gestion(rol, cadenaConexion).Show();
        }

        private void productosDisponibles(object sender, EventArgs e)
        {
            foreach (object item in listBox1.SelectedItems)
            {
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
                string nombre = (string)dr["Nombre"];
                double precio = (double)dr["Precio"];
                int stock = (int)dr["Stock"];
                Cesta.Add(new Producto(nombre, 0, stock, precio));
            }
            foreach(Producto p in Cesta)
            {
                if(p.getCantidadTotl() != 0)
                {
                    listBox1.Items.Add(p.getNombre());
                }
               
            }
        }

        private void productosEnCesta(object sender, EventArgs e)
        {
            foreach (object item in listBox2.SelectedItems)
            {
                SelectItemCart = (string)item;
            }
        }
    }
}
