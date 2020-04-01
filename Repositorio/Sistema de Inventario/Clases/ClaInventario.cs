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
        private double precio;
        private ClaConexion conexion;
        private MySqlException error;

        public ClaInventario()
        {
            idInventario = 0;
            producto = string.Empty;
            existencia = 0;
            precio = 0.00;
            conexion = new ClaConexion();
        }

        public ClaInventario(int c, string p, int e, double pre)
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

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public Boolean BuscarProducto(string nombre)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT idInventario, producto, existencia, precio FROM taller.inventario where producto='{0}'", nombre));
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
        public MySqlException Error
        {
            get { return error; }
        }
    }
}
