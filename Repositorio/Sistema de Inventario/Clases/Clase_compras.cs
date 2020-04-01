using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Inventario.Clases
{
    class Clase_compras
    {
        private int numeroFactura;
        private int encabezado;
        private int idProducto;
        private string cliente;
        private int cantidad;
        private decimal precio;
        private decimal impuesto;
        private decimal subtotal;
        private decimal total;
        private DateTime fecha;


        public Clase_compras()
        {
            numeroFactura = 0;
            encabezado = 0;
            idProducto = 0;
            cliente = "";
            cantidad = 0;
            precio = 0;
            impuesto = 0;
            subtotal = 0;
            total = 0;
      
        }

        public Clase_compras(int NumeroFactura, int Encabezado,int IDProducto,string Cliente,int Cantidad,decimal Precio,decimal Impuesto,decimal Subtotal,decimal Total,DateTime Fecha)
        {
            numeroFactura = NumeroFactura;
            encabezado = Encabezado;
            idProducto = IDProducto;
            cliente = Cliente;
            cantidad = Cantidad;
            precio = Precio;
            impuesto = Impuesto;
            subtotal = Subtotal;
            total = Total;
        }

        public int NumeroFactura
        {
            get => numeroFactura;
            set
            {
                numeroFactura = value;
            }
        }
        public int Encabezado
        {
            get => encabezado;
            set
            {
                encabezado = value;
            }
        }

        public DateTime Fecha
        {
            get => fecha;
            set
            {
                fecha = value ;
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
            if (conexion.IUD(string.Format("INSERT INTO detalleventa (encabezado, producto, cantidad,precio,impuesto,subtotal,total ) value('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", Encabezado, IDProducto, Cantidad,Precio,Impuesto,Subtotal,Total)))
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

        public Boolean BuscarCategoria(string no)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT numeroFactura, cliente, fecha FROM BDTaller.encabezadoventa where numeroFactura='{0}'", no));
            if (t1.Rows.Count > 0)
            {
                NumeroFactura = t1.Rows[0][0].ToString();
                cliente = Convert.ToInt32(t1.Rows[0][1].ToString());
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