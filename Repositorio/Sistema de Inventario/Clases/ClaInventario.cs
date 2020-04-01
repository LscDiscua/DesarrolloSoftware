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
    class ClaInventario
    {
        private int idInventario;
        private string producto;
        private int existencia;
        private decimal precio;
        private ClaConexion conexion;
        private MySqlException error;

        public ClaInventario()
        {
            idInventario = 0;
            producto = string.Empty;
            existencia = 0;
            precio = 0;
            conexion = new ClaConexion();
        }

        public ClaInventario(int c, string p, int e, decimal pre)
        {
            idInventario = c;
            producto = p;
            existencia = e;
            precio = pre;
            conexion = new ClaConexion();
        }

        public int IdInventario
        {
            get { return idInventario; }
            set { idInventario = value; }
        }

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public int Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public Boolean BuscarProducto(string id)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT idInventario, producto, existencia, precio FROM taller.inventario where producto='{0}'", id));
            if (t1.Rows.Count > 0)
            {
                idInventario = Convert.ToInt32(t1.Rows[0][0].ToString());
                producto = t1.Rows[0][1].ToString();
                existencia = Convert.ToInt32(t1.Rows[0][2].ToString());
                precio = Convert.ToInt32(t1.Rows[0][3].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean GuardarInventario()
        {
         
            if (conexion.IUD(string.Format("INSERT INTO  taller.inventario(producto, existencia, precio)" +
                "select distinct producto, cantidad, precio from taller.detallecompra; value('{0}','{1}','{2}')",Producto,Existencia,Precio)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean ModificarInventario()
        {
            
            if (conexion.IUD(string.Format("UPDATE taller.inventario AS inv INNER JOIN taller.detalleventa AS dv" +
                "ON  inv.producto = dv.producto SET inv.existencia = inv.existencia - dv.cantidad  '{0}'" +
                "WHERE idInventario > 1; ", Existencia,IdInventario)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }



        public MySqlException Error
        {
            get { return error; }
        }
    }
}
