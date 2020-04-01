using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_de_Inventario
{
    class ClaConexion
    {
        private MySqlConnection conexion;
        private string bd;
        private string servidor;
        private string usuario;
        private string pass;
        private MySqlException error;

        public ClaConexion()
        {
            bd = "taller";
            servidor = "127.0.0.1";
            usuario = "Taller";
            pass = "desarrollo01";
            conexion = new MySqlConnection();
        }
        public ClaConexion(string b, string se, string u, string p)
        {
            bd = b;
            servidor = se;
            usuario = u;
            pass = p;
            conexion = new MySqlConnection();
        }
        public void conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.ConnectionString = string.Format("Database={0};Server={1};Uid={2};Pwd={3};SslMode=none", bd, servidor, usuario, pass);
                    conexion.Open();
                    
                }
                else
                {
                    conexion.Close();
                    conexion.ConnectionString = string.Format("Database={0};Server={1};Uid={2};Pwd={3};SslMode=none", bd, servidor, usuario, pass);
                    conexion.Open();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("Error: \n{0}", ex.ToString()), "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public DataTable consulta(string sql)
        {
            DataTable t = new DataTable();
            conectar();
            MySqlCommand comando = conexion.CreateCommand();
            MySqlDataAdapter adptador = new MySqlDataAdapter();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = sql;
                adptador.SelectCommand = comando;
                adptador.Fill(t);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("Error: \n{0}", ex.ToString()), "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return t;
        }

        /*public DataTable ObtenerNumerodeFactura(string sql)
        {
            DataTable t = new DataTable();
            conectar();
            MySqlCommand comando = conexion.CreateCommand();
            MySqlDataAdapter adptador = new MySqlDataAdapter();
           
            try
            {
                comando.Connection = conexion;
                comando.CommandText = sql;
                adptador.SelectCommand = comando;
                //adptador.Fill(t);
              
                SqlCommand sqlCommand = new SqlCommand(sql );
                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        
                        Clases.ClaVenta venta = new Clases.ClaVenta();

                        venta.Encabezado = Convert.ToInt32(rdr["numeroFactura"]);

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("Error: \n{0}", ex.ToString()), "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return t;
        }*/

        public ClaConexion ObtenerNumerodeFactura()
        {
            ClaConexion numero = new ClaConexion();

            try
            {
                // Query de selección
                string sql = @"SELECT * FROM taller.encabezadoventa where numeroFactura = (select Max(numeroFactura) from taller.encabezadoventa";

                // Abrir la conexión
                conexion.Open();

                // Establecer el comando SQL
                MySqlCommand sqlCommand = new MySqlCommand(sql, conexion);

                using (MySqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Clases.ClaVenta venta = new Clases.ClaVenta();

                        venta.Encabezado = Convert.ToInt32(rdr["numeroFactura"]);
                    }
                }
                return numero;

                /* Ventas ven = new Ventas();
                 ven.txtfactura.Text = IdVenta.ToString();*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Cerrar la conexión
                conexion.Close();
            }

        }



        public Boolean IUD(string sql)
        {
            conectar();
            MySqlCommand comando = conexion.CreateCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                error = ex;
                return false;
            }
        }
        public MySqlException Error
        {
            get { return error; }
        }
    }
}
