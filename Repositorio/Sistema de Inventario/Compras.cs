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
        private Clases.ClaProducto producto;

        private Clases.ClaListaCompras compras;
        private ClaCompra compra;

        private Clases.ClaListaProveedores proveedores;
        private Clases.ClaProveedor proveedor;

        public Compras()
        {
            InitializeComponent();
            c = new ClaConexion();
            productos = new Clases.ClaListaProductos();
            compras = new Clases.ClaListaCompras();

            proveedores = new Clases.ClaListaProveedores();
            proveedor = new Clases.ClaProveedor();

            producto = new Clases.ClaProducto();
            compra = new ClaCompra();
<<<<<<< HEAD
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();

            /*DataTable t2 = compras.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor, d.idDetalleCompra , " +
                "d.encabezadoCompra, d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t2;
            dataGridView1.Refresh();*/

            DataTable t2 = compras.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor , " +
                " d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t2;
            dataGridView1.Refresh();

            DataTable t3 = proveedores.SQL(String.Format("SELECT idProveedor, RTNProveedor, nombre, telefono, " +
                "direccion, correoElectronico FROM taller.proveedor"));

            cbxProveedor.DataSource = null;
            cbxProveedor.DataSource = t3;
            cbxProveedor.DisplayMember = "nombre";
            cbxProveedor.ValueMember = "idProveedor";
            cbxProveedor.Refresh();

        }

=======
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();

            /*DataTable t2 = compras.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor, d.idDetalleCompra , " +
                "d.encabezadoCompra, d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t2;
            dataGridView1.Refresh();*/

            DataTable t2 = compras.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor , " +
                " d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = t2;
            dataGridView1.Refresh();

            DataTable t3 = proveedores.SQL(String.Format("SELECT idProveedor, RTNProveedor, nombre, telefono, " +
                "direccion, correoElectronico FROM taller.proveedor"));

            cbxProveedor.DataSource = null;
            cbxProveedor.DataSource = t3;
            cbxProveedor.DisplayMember = "nombre";
            cbxProveedor.ValueMember = "idProveedor";
            cbxProveedor.Refresh();

        }

>>>>>>> ccce27706f76fc7a24fb1887121e854a9f325335

        private void Cargar_Datos()
        {
            txtNumeroFactura.Text = compra.NumeroFactura;
            cbxProveedor.SelectedValue = compra.Proveedor;
            dtpFecha.Text = compra.Fecha.ToString();
            cbxProveedor.SelectedValue = compra.Proveedor;
            txtFacturaProveedor.Text = compra.FacturaProveedor;

            txtNumeroFactura.Text = compra.EncabezadoCompra;
            txtProducto.Text = compra.Producto;
            txtCantidad.Text = compra.Cantidad.ToString();
            txtPrecio.Text = compra.Precio.ToString();
            txtImpuesto.Text = compra.Impuesto.ToString();
            txtSubTotal.Text = compra.SubTotal.ToString();
            txtTotal.Text = compra.Total.ToString();

            txtNumeroFactura.Focus();
            SendKeys.Send("{Tab}");
        }
        private void limpiar()
        {

            txtNumeroFactura.Text = "";
            cbxProveedor.SelectedValue = "";
            dtpFecha.Value = DateTime.Today;
            cbxProveedor.SelectedValue = "";
            txtFacturaProveedor.Text = "";

            txtNumeroFactura.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtImpuesto.Text = "";
            txtSubTotal.Text = "";
            txtTotal.Text = "";
            txtNumeroFactura.Focus();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtNumeroFactura.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbxProveedor.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtpFecha.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //txtFecha.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtFacturaProveedor.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtProducto.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCantidad.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtImpuesto.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtSubTotal.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtTotal.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtProducto.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                compra.NumeroFactura = txtNumeroFactura.Text;
                compra.Proveedor = Convert.ToInt32(cbxProveedor.SelectedValue);
                compra.Fecha = dtpFecha.Value;
                compra.FacturaProveedor = txtFacturaProveedor.Text;

                compra.EncabezadoCompra = txtNumeroFactura.Text;
                compra.Producto = txtProducto.Text;
                compra.Cantidad = Convert.ToInt32(txtCantidad.Text);
                compra.Precio = Convert.ToDecimal(txtPrecio.Text);
                compra.Impuesto = Convert.ToDecimal(txtImpuesto.Text);
                compra.SubTotal = (Convert.ToInt32(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text));
                compra.Total = (Convert.ToInt32(txtImpuesto.Text) * Convert.ToInt32(txtSubTotal.Text));

                if (compra.GuardarEncabezado())
                {
                    MessageBox.Show("Registro guardado correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t2 = compras.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor , " +
                " d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = t2;
                    dataGridView1.Refresh();

                }
                else if (compra.GuardarDetalle())
                {
                    MessageBox.Show("Registro guardado correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t2 = compras.SQL(String.Format("SELECT e.numeroFactura, e.proveedor, e.fecha, e.facturaProveedor , " +
                " d.producto, d.cantidad, d.precio, d.impuesto,d.subTotal, d.total FROM taller.encabezadoCompra " +
                "As e INNER JOIN taller.detalleCompra AS d ON e.numeroFactura = d.encabezadoCompra"));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = t2;
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", compra.Error.ToString()), "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (compra.BuscarEncabezado(txtNumeroFactura.Text))
            {
                MessageBox.Show(string.Format("Ya existe existe este numero de factura\n{0}\t{1}", compra.NumeroFactura, compra.FacturaProveedor));
                r = false;
            }
            else if (compra.BuscarEncabezado(txtFacturaProveedor.Text))
            {
                MessageBox.Show(string.Format("Ya existe el nombre del Producto\n{0}\t{1}", compra.NumeroFactura, compra.FacturaProveedor));

                r = false;
            }
            else
                r = true;
            return r;

        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            decimal p, c, i;

            //i = Convert.ToDecimal(txtSubTotal.Text);
            p = Convert.ToDecimal(txtPrecio.Text);
            c = Convert.ToDecimal(txtCantidad.Text);
            i = (c * p);
            txtSubTotal.Text = i.ToString();
        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e){}

        private void txtImpuesto_Leave(object sender, EventArgs e)
        {
            decimal im, su, to;
            //to = Convert.ToDecimal(txtTotal.Text);
            im = Convert.ToDecimal(txtImpuesto.Text);
            su = Convert.ToDecimal(txtSubTotal.Text);
            to = (im + su);
            txtTotal.Text = to.ToString();
        }
<<<<<<< HEAD
=======

        private void label1_Click(object sender, EventArgs e)
        {

        }
>>>>>>> ccce27706f76fc7a24fb1887121e854a9f325335
    }
}



