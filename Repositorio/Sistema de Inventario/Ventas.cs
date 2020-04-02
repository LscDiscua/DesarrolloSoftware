using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Inventario
{
    public partial class Ventas : Form
    {
        ClaConexion c;
        private Clases.ClaListaProductos productos;
        private Clases.ClaListaVentas ventas;
        private Clases.ClaVenta encabezadoVenta;
        public Ventas()
        {
           
            InitializeComponent();
            c = new ClaConexion();
            productos = new Clases.ClaListaProductos();
            ventas = new Clases.ClaListaVentas();
            encabezadoVenta = new Clases.ClaVenta();
            GenerarEncabezado();
            Bloqueartxt();
            Limpiar();

        }

        /// <summary>
        /// deja en blanco todos los txt menos el encabezado de Venta
        /// </summary>
        private void Limpiar()
        {
            txtTotal.Text = string.Empty;
            txtBuscarProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtImpuesto.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtProducto.Text = string.Empty;
        }
        /// <summary>
        /// bloquea los txt especificados para que no se pueda modificar su valor manualmente
        /// </summary>
        private void Bloqueartxt()
        {
            txtEncabezadoVenta.Enabled = false;
            txtPrecio.Enabled = false;
            txtSubtotal.Enabled = false;
            txtTotal.Enabled = false;

        }

        private void Ventas_Load_1(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();

            DataTable t2 = ventas.SQL(String.Format("SELECT ev.numeroFactura, ev.fecha, ev.cliente, dv.idDetalle, dv.encabezado, " +
                "dv.producto, dv.cantidad, dv.precio, dv.impuesto, dv.subTotal, dv.total FROM taller.encabezadoventa As ev " +
                "INNER JOIN taller.detalleventa AS dv ON ev.numeroFactura = dv.encabezado"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t2;
            dataGridView1.Refresh();
        }
        private void Ventas_Load(object sender, EventArgs e){}

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GenerarEncabezado()
        {
            Limpiar();
            encabezadoVenta.GenerarEncabezado();
            encabezadoVenta.MostarNumeroEncabezado();
            txtEncabezadoVenta.Text = encabezadoVenta.Encabezado.ToString();
        }
        private void btnTerminarVenta_Click(object sender, EventArgs e)
        {
            GenerarEncabezado();
        }
    }
}
