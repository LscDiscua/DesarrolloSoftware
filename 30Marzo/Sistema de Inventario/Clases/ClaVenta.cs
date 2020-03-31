using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms; 

namespace Sistema_de_Inventario.Clases
{
    class ClaVenta
    {
        /// Detalle Venta
        private int idDetalle;
        private int encabezado;
        private string idProducto;
        private int cantidad;
        private decimal precio;
        private decimal impuesto;
        private decimal subtotal;
        private decimal total;

        // Encabezado Venta
        private int numeroFactura;
        private DateTime fecha;
        private string cliente;

        private ClaConexion conexion;
        private MySqlException error;


        public ClaVenta()
        {
            encabezado = 0;
            idProducto = string.Empty;
            cliente = "";
            cantidad = 0;
            precio = 0;
            impuesto = 0;
            subtotal = 0;
            total = 0;
            idDetalle = 0;
            numeroFactura = 0;
            fecha = DateTime.Today;
            conexion = new ClaConexion();

        }

        public ClaVenta(int Encabezado,string IDProducto,string Cliente,int Cantidad,decimal Precio,decimal Impuesto,decimal Subtotal,decimal Total, int IdDetalle,
            int Factura, DateTime Fecha)
        {

            encabezado = Encabezado;
            idProducto = IDProducto;
            cliente = Cliente;
            cantidad = Cantidad;
            precio = Precio;
            impuesto = Impuesto;
            subtotal = Subtotal;
            total = Total;
            idDetalle = IdDetalle;
            numeroFactura = Factura;
            fecha = Fecha;

            conexion = new ClaConexion();
        }

        public int Encabezado
        {
            get => encabezado;
            set
            {
                encabezado = value;
            }
        }

        public string IDProducto
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


        public int NumeroFactura
        {
            get { return numeroFactura; }
            set { value = numeroFactura;  }
        }


        public int IdDetalle
        {
            get { return idDetalle; }
            set { value = idDetalle; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { value = fecha; }
        }

        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO encabezadoventa ( cliente, fecha ) value('{0}','{1}')", Cliente, Fecha)))
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
            if (conexion.IUD(string.Format("INSERT INTO detalleventa (encabezado, producto, cantidad,precio,impuesto,subtotal,total ) value('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Encabezado, IDProducto, Cantidad, Precio, Impuesto, Subtotal, Total)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean Modificar()
        {
            if (conexion.IUD(string.Format("UPDATE encabezadoventa SET cliente = '{0}',  fecha = {1}  WHERE numeroFactura = {2}", Cliente, Fecha, NumeroFactura)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean ModificarDetalleVenta()
        {
            if (conexion.IUD(string.Format("UPDATE detalledoventa SET encabezado = {0}, producto = '{1}', cantidad = {2}, precio = {3}, " +
                "impuesto = {4}  WHERE idDetalle = {5}", Encabezado, IDProducto, Cantidad, Precio, Impuesto, IdDetalle)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean BuscarEncabezadoVenta(string no)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT numeroFactura, cliente, fecha FROM taller.encabezadoventa where numeroFactura= {0}", no));
            if (t1.Rows.Count > 0)
            {
                NumeroFactura = Convert.ToInt32(t1.Rows[0][0].ToString());
                Cliente = t1.Rows[0][1].ToString();
                Fecha = Convert.ToDateTime(t1.Rows[0][2].ToString());
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