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

        private Clases.ClaVenta venta;
        public Ventas()
        {
            InitializeComponent();
            c = new ClaConexion();
            productos = new Clases.ClaListaProductos();
            ventas = new Clases.ClaListaVentas();

            venta = new Clases.ClaVenta();
            venta.IniciarEncabezado();
            //venta.Fecha = dtpFechaVenta.Value;
            venta.Cliente = txtCliente.Text;
            txtNumeroFactura.Enabled = false;
          
                    
        }

        private void Ventas_Load_1(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();

            DataTable t2 = ventas.SQL(String.Format("SELECT ev.numeroFactura, ev.fecha, ev.cliente, " +
                "dv.producto, dv.cantidad, dv.precio, dv.impuesto, dv.subTotal, dv.total FROM taller.encabezadoventa As ev " +
                "INNER JOIN taller.detalleventa AS dv ON ev.numeroFactura = dv.encabezado"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t2;
            dataGridView1.Refresh();


        }

        private void Cargar_Datos()
        {

            txtNumeroFactura.Text = venta.NumeroFactura.ToString();
            dtpFechaVenta.Text = venta.Fecha.ToString();
            txtCliente.Text = venta.Cliente;


            txtNumeroFactura.Text = venta.Encabezado.ToString();
            txtProducto.Text = venta.IDProducto;
            txtCantidad.Text = venta.Cantidad.ToString();
            txtPrecio.Text = venta.Precio.ToString();
            txtImpuesto.Text = venta.Impuesto.ToString();
            txtSubTotal.Text = venta.Subtotal.ToString();
            txtTotal.Text = venta.Total.ToString();

            txtNumeroFactura.Focus();
            SendKeys.Send("{Tab}");
        }
        private void limpiar()
        {

            txtNumeroFactura.Text = "";
            dtpFechaVenta.Value = DateTime.Today;
            txtCliente.Text = "";
          
            txtNumeroFactura.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtImpuesto.Text = "";
            txtSubTotal.Text = "";
            txtTotal.Text = "";
            txtNumeroFactura.Focus();

        }
        private void Ventas_Load(object sender, EventArgs e){}

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            //venta.Fecha
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e){}

        private void textBox5_TextChanged(object sender, EventArgs e){}

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtNumeroFactura.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dtpFechaVenta.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtProducto.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtCantidad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtImpuesto.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtSubTotal.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTotal.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                //venta.NumeroFactura = Convert.ToInt32(txtNumeroFactura.Text);
                venta.Fecha = dtpFechaVenta.Value;
                venta.Cliente = txtCliente.Text;
                venta.Encabezado = Convert.ToInt32(txtNumeroFactura.Text);
                venta.IDProducto = txtProducto.Text;
                venta.Cantidad = Convert.ToInt32(txtCantidad.Text);
                venta.Precio = Convert.ToDecimal(txtPrecio.Text);
                venta.Impuesto = Convert.ToDecimal(txtImpuesto.Text);
                venta.Subtotal = Convert.ToDecimal(txtSubTotal.Text);
                venta.Total = Convert.ToDecimal(txtSubTotal.Text);

                if (venta.Modificar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t2 = ventas.SQL(String.Format("SELECT ev.numeroFactura, ev.fecha, ev.cliente, " +
                "dv.producto, dv.cantidad, dv.precio, dv.impuesto, dv.subTotal, dv.total FROM taller.encabezadoventa As ev " +
                "INNER JOIN taller.detalleventa AS dv ON ev.numeroFactura = dv.encabezado"));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = t2;
                    dataGridView1.Refresh();

                }
                else if (venta.GuardarDetalle())
                {
                    MessageBox.Show("Registro guardado correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t2 = ventas.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor , " +
                " d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = t2;
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", venta.Error.ToString()), "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Se cancelo la edición");

            }
            limpiar();
        }

        private Boolean Validar()
        {
            Boolean r = true;
            if (txtNumeroFactura.Text == "")
            {
                MessageBox.Show("Escriba el codigo del producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroFactura.Focus();
                r = false;
            }
            if (txtProducto.Text == "")
            {
                MessageBox.Show("Escriba el nombre del producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProducto.Focus();
                r = false;
            }
            else
                r = true;
            return r;

        }
    }
}
