using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEva1_TPV
{
    internal class Producto
    {
        String Nombre;
        int Cantidad;
        double Precio;

        public Producto(string nombre, int cantidad, double precio)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }

        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }
        public void setCantidad(int cantidad)
        {
            this.Cantidad = cantidad;
        }
        public void setPrecio(double precio)
        {
            this.Precio = precio;
        }
        public string getNombre()
        {
            return Nombre;
        }
        public int getCantidad()
        {
            return Cantidad;
        }
        public double getPrecio()
        {
            return Precio;
        }
    }
}
