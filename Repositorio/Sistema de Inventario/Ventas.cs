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
<<<<<<< HEAD
        private Clases.ClaVenta encabezadoVenta;
=======

        private Clases.ClaVenta venta;
>>>>>>> ccce27706f76fc7a24fb1887121e854a9f325335
        public Ventas()
        {
            
            InitializeComponent();
            c = new ClaConexion();
            productos = new Clases.ClaListaProductos();
            ventas = new Clases.ClaListaVentas();
<<<<<<< HEAD
            encabezadoVenta = new Clases.ClaVenta();
            encabezadoVenta.Guardar();
            encabezadoVenta.Fecha = CFecha.Value;

        }

        private void Limpiar()
        {
            txtbuscarproducto.Text = string.Empty;
            txtcantidad.Text = string.Empty;
            txtcliente.Text = string.Empty;
            txtimpuesto.Text = string.Empty;
            txtnumerodefactura.Text = string.Empty;
            txtprecio.Text = string.Empty;
            txtproducto.Text = string.Empty;
            txtsubtotal.Text = string.Empty;
            txttotal.Text = string.Empty;
=======

            venta = new Clases.ClaVenta();
            venta.Fecha = DateTime.Today;
            venta.Guardar();

            //venta.Encabezado = Convert.ToInt32(txtNumeroFactura.Text);          
>>>>>>> ccce27706f76fc7a24fb1887121e854a9f325335
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

<<<<<<< HEAD
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
            encabezadoVenta.Guardar();
            encabezadoVenta.Fecha = CFecha.Value;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
=======
        private void label1_Click(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            //venta.Fecha
>>>>>>> ccce27706f76fc7a24fb1887121e854a9f325335
        }
    }
}
