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
    public partial class Compras : Form
    {
        ClaConexion c;
        private Clases.ClaListaProductos productos;
        private Clases.ClaListaCompras compras;

        public Compras()
        {
            InitializeComponent();
            c = new ClaConexion();
            productos = new Clases.ClaListaProductos();
            compras = new Clases.ClaListaCompras();
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();

            DataTable t2 = compras.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor, d.idDetalleCompra , " +
                "d.encabezadoCompra, d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t2;
            dataGridView1.Refresh();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
