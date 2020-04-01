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
    class ClaProducto
    {
        private string idProducto;
        private string nombre;
        private int categoria;
        private string marca;
        private string año;
        private int proveedor;
        private ClaConexion conexion;

        private MySqlException error;
        public ClaProducto()
        {
            idProducto = string.Empty;
            nombre = string.Empty;
            categoria = 0;
            marca = string.Empty;
            año = "0000";
            proveedor = 0;

            conexion = new ClaConexion();
        }

        public ClaProducto(string n, string m, string a)
        {
            idProducto = string.Empty;
            nombre = n;
            categoria = 0;
            marca = m;
            año = a;
            proveedor = 0;

            conexion = new ClaConexion();
        }

        public string IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }

        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Año
        {
            get { return año; }
            set { año = value; }
        }
        public int Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO producto (idProducto, nombre, categoria, marca, año, proveedor) value('{0}','{1}', " +
                "{2}, '{3}', '{4}', {5})", IdProducto, Nombre, Categoria, Marca, Año, Proveedor)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean ModificarProducto()
        {
            if (conexion.IUD(string.Format("UPDATE taller.producto SET nombre='{0}', categoria= {1}, marca = '{2}', año = '{3}', proveedor = {4}  " +
                "WHERE idProducto= '{5}'", Nombre, Categoria, Marca, Año, Proveedor, IdProducto)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean Eliminar()
        {
            if (conexion.IUD(string.Format("DELETE FROM taller.producto WHERE idProducto= {0}", IdProducto)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }
        public Boolean BuscarProducto(string no)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto where nombre='{0}'", no));
            if (t1.Rows.Count > 0)
            {
                IdProducto = (t1.Rows[0][0].ToString());
                Nombre = t1.Rows[0][1].ToString();
                Categoria= Convert.ToInt32(t1.Rows[0][2].ToString());
                Marca = t1.Rows[0][3].ToString();
                Año = (t1.Rows[0][4].ToString());
                Proveedor = Convert.ToInt32(t1.Rows[0][5].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean BuscarIdProducto(string id)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto where idProducto='{0}'", id));
            if (t1.Rows.Count > 0)
            {
                IdProducto = (t1.Rows[0][0].ToString());
                Nombre = t1.Rows[0][1].ToString();
                Categoria = Convert.ToInt32(t1.Rows[0][2]);
                Marca = t1.Rows[0][3].ToString();
                Año = (t1.Rows[0][4].ToString());
                Proveedor = Convert.ToInt32(t1.Rows[0][5]);
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
