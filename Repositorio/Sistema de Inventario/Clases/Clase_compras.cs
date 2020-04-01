using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario.Clases
{
    class Clase_compras
    {
        private int encabezado;
        private int idProducto;
        private string cliente;
        private int cantidad;
        private decimal precio;
        private decimal impuesto;
        private decimal subtotal;
        private decimal total;


        public Clase_compras()
        {
            encabezado = 0;
            idProducto = 0;
            cliente = "";
            cantidad = 0;
            precio = 0;
            impuesto = 0;
            subtotal = 0;
            total = 0;
      
        }

        public Clase_compras(int Encabezado,int IDProducto,string Cliente,int Cantidad,decimal Precio,decimal Impuesto,decimal Subtotal,decimal Total)
        {

            encabezado = Encabezado;
            idProducto = IDProducto;
            cliente = Cliente;
            cantidad = Cantidad;
            precio = Precio;
            impuesto = Impuesto;
            subtotal = Subtotal;
            total = Total;
        }

        public int Encabezado
        {
            get => encabezado;
            set
            {
                encabezado = value;
            }
        }

        public int IDProducto
        {
            get => idProducto;
            set
            {
                idProducto = value;
            }
        }

        public string Cliente
        {
            get => cliente;
            set
            {
                cliente = value;
            }
        }

        public int Cantidad
        {
            get => cantidad;
            set
            {
                cantidad = value;
            }
        }

        public decimal Precio
        {
            get => precio;
            set
            {
                precio = value;
            }
        }

        public decimal Impuesto
        {
            get => precio;
            set
            {
                precio = value;
            }
        }

        public decimal Subtotal
        {
            get => subtotal;
            set
            {
                subtotal = value;
            }
        }

        public decimal Total
        {
            get => total;
            set
            {
                total = value;
            }
        }

    }
}