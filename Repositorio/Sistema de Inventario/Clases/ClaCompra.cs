using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sistema_de_Inventario
{
    class ClaCompra
    {
        //----- Encabezado Compra
        private string numeroFactura;
        private int proveedor;
        private DateTime fecha;
        private string facturaProveedor;
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
        private MySqlException error;


        public ClaCompra()
        {
            numeroFactura = "0000";
            proveedor = 0;
            fecha = DateTime.Today;
            facturaProveedor = string.Empty;

            idDetalleCompra = 0;
            encabezadoCompra = "0000";
            producto = "0000";
            cantidad = 0;
            precio = 0;
            impuesto = 0;
            subTotal = 0;
            total = 0;
            conexion = new ClaConexion();
        }

        public ClaCompra(string noFac, int pro, DateTime fe, string facPro, int idDetalle, string encaCompra, string produc, int can,
            decimal pre, decimal imp, decimal subt, decimal tot)
        {
            numeroFactura = noFac;
            proveedor = pro;
            fecha = fe;
            facturaProveedor = facPro;

            idDetalleCompra = idDetalle;
            encabezadoCompra = encaCompra;
            producto = produc;
            cantidad = can;
            precio = pre;
            impuesto = imp;
            subTotal = subt;
            total = tot;
            conexion = new ClaConexion();
        }


        public string NumeroFactura
        {
            get { return numeroFactura; }

            set { value = numeroFactura; }
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


        public string FacturaProveedor
        {
            get { return facturaProveedor; }

            set { value = facturaProveedor; }
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


        public Boolean GuardarEncabezado()
        {
            if (conexion.IUD(string.Format("INSERT INTO taller.encabezadoCompra (numeroFactura, proveedor, fecha, facturaProveedor ) value('{0}','{1}','{2}','{3}')", NumeroFactura, Proveedor
                ,Fecha, FacturaProveedor)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean GuardarDetalle()
        {
            if (conexion.IUD(string.Format("INSERT INTO taller.detalleCompra ( encabezadoCompra, producto, cantidad, precio, impuesto, subtotal, total ) " +
                "value('{0}','{1}','{2}', '{3}','{4}', '{5}', '{6}')", EncabezadoCompra, Producto, Cantidad,Precio, Impuesto, SubTotal,Total)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean ModificarEncabezado()
        {
            if (conexion.IUD(string.Format("UPDATE encabezadoCompra SET proveedor = '{0}',  fecha = {1}, facturaProveedor = '{2}' WHERE numeroFactura={3}", Proveedor, Fecha, FacturaProveedor,NumeroFactura))) 
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        
        public Boolean ModificarDetalle()
        {
            if (conexion.IUD(string.Format("UPDATE detalleCompra SET  encabezadoCompra = '{0}',  producto = '{1}', cantidad = {2}, precio = {3}, impuesto = {4}" +
                " WHERE idDetalleCompra={5}", EncabezadoCompra, Producto, Producto, Cantidad, Precio, Impuesto, IdDetalleCompra)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean BuscarEncabezado(string no)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT numeroFactura, proveedor, fecha, " +
                "facturaProveedor FROM taller.encabezadoCompra where numeroFactura='{0}'", no));
            if (t1.Rows.Count > 0)
            {
                NumeroFactura= t1.Rows[0][0].ToString();
                Proveedor = Convert.ToInt32(t1.Rows[0][1].ToString());
                Fecha = Convert.ToDateTime(t1.Rows[0][2].ToString());
                FacturaProveedor = t1.Rows[0][0].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean BuscarDetalleCompra(string no)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT idDetalleCompra, encabezadoCompra, producto, " +
                "cantidad, precio, impuesto, subtotal, total FROM taller.detalleCompra where idDetalleCompra ={0}", no));
            if (t1.Rows.Count > 0)
            {
                IdDetalleCompra = Convert.ToInt32(t1.Rows[0][0].ToString());
                EncabezadoCompra =t1.Rows[0][1].ToString();
                Producto = t1.Rows[0][2].ToString();
                Cantidad = Convert.ToInt32(t1.Rows[0][3].ToString());
                Precio = Convert.ToInt32(t1.Rows[0][4].ToString());
                Impuesto = Convert.ToInt32(t1.Rows[0][5].ToString());
                SubTotal = Convert.ToInt32(t1.Rows[0][6].ToString());
                Total = Convert.ToInt32(t1.Rows[0][7].ToString());

                return true;
            }
            else
            {
                return false;
            }
        }
        public MySqlException Error
        {
            get { return error; }
        }

    }
}

