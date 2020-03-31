using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario
{
    class ClaCompra
    {
        //----- Encabezado Compra
        private string numeroFactura;
        private int proveedor;
        private DateTime fecha;
        ////-------Detalle Compra
        private int idDetalleCompra;
        private string encabezadoCompra;
        private string producto;
        private int cantidad;
        private decimal precio;
        private decimal impuesto;
        private decimal subTotal;
        private decimal total;

        private ClaConexion conexion;

        public ClaCompra()
        {
            numeroFactura = "0000";
            proveedor = 0;
            fecha = DateTime.Today;

            idDetalleCompra = 0;
            encabezadoCompra = "0000";
            producto = "0000";
            cantidad = 0;
            precio = 0;
            impuesto = 0;
            subTotal = 0;
            total = 0;
        }

        public ClaCompra(string noFac, int pro, DateTime fe, int idDetalle, string encaCompra, string produc, int can,
            decimal pre, decimal imp, decimal subt, decimal tot)
        {
            numeroFactura = noFac;
            proveedor = pro;
            fecha = fe;

            idDetalleCompra = idDetalle;
            encabezadoCompra = encaCompra;
            producto = produc;
            cantidad = can;
            precio = pre;
            impuesto = imp;
            subTotal = subt;
            total = tot;
        }

    
        public string NumeroFactura
        {
            get{ return numeroFactura; }

            set{ value = numeroFactura;}
        }
        
        public int Proveedor 
        {
            get { return proveedor; }
            set { value = proveedor; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { value = fecha; }
        }

        ///----------------
        public int IdDetalleCompra
        {
            get { return idDetalleCompra; }
            set { value = idDetalleCompra; }
        }

        public string EncabezadoCompra
        {
            get { return encabezadoCompra; }
            set { value = encabezadoCompra; }
        }

        public string Producto
        {
            get { return producto; }
            set { value = producto; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { value = cantidad; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { value = precio; }
        }

        public decimal Impuesto
        {
            get { return impuesto; }
            set { value = impuesto; }
        }

        public decimal SubTotal
        {
            get { return subTotal; }
            set { value = subTotal; }
        }

        public decimal Total
        {
            get { return total; }
            set { value = total; }
        }

    }
}
