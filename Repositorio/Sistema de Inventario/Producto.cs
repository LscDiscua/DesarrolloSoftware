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
    public partial class Producto : Form
    {
        ClaConexion c;
        private Clases.ClaListaProductos productos;
        private Clases.ClaProducto producto;

        private Clases.ClaListaCategorias categorias;
        private ClaCategoria categoria;

        private Clases.ClaListaProveedores proveedores;
        private Clases.ClaProveedor proveedor;
        public Producto()
        {
            InitializeComponent();
            c = new ClaConexion();
            productos = new Clases.ClaListaProductos();
            producto = new Clases.ClaProducto();

            categorias = new Clases.ClaListaCategorias();
            categoria = new ClaCategoria();

            proveedores = new Clases.ClaListaProveedores();
            proveedor = new Clases.ClaProveedor();

            
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();

            DataTable t2 = categorias.SQL(String.Format("SELECT idCategoria, nombre, descripcion FROM " +
                "taller.categoria "));
            
                cbxCategoria.DataSource = null;
                cbxCategoria.DataSource = t2;
                cbxCategoria.DisplayMember = "nombre";
                cbxCategoria.ValueMember = "idCategoria";
                cbxCategoria.Refresh();
  

            DataTable t3 = proveedores.SQL(String.Format("SELECT idProveedor, RTNProveedor, nombre, telefono, " +
                "direccion, correoElectronico FROM taller.proveedor"));
            
                cbxProveedor.DataSource = null;
                cbxProveedor.DataSource = t3;
                cbxProveedor.DisplayMember = "nombre";
                cbxProveedor.ValueMember = "idProveedor";
                cbxProveedor.Refresh();
          

        }

        private void button2_Click(object sender, EventArgs e){}

        private void button3_Click(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e){}

        private void textBox3_TextChanged(object sender, EventArgs e){}

        private void panel4_Paint(object sender, PaintEventArgs e){}

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){}

        private void Cargar_Datos()
        {
            txtIdProducto.Text = producto.IdProducto.ToString();
            txtNombreProducto.Text = producto.Nombre;
            cbxCategoria.SelectedValue = producto.Categoria;
            txtAño.Text = producto.Año;
            cbxProveedor.SelectedValue = producto.Proveedor;
            txtMarca.Text = producto.Marca;
            txtIdProducto.Focus();
            SendKeys.Send("{Tab}");
        }
        private void limpiar()
        {
            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            txtAño.Text = "";
            txtMarca.Text = "";
            //txtIdProducto.Enabled = true;
            txtIdProducto.Focus();
            cbxCategoria.Text= "";
            cbxProveedor.Text = "";

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cbxCategoria.SelectedValue.ToString());
            //MessageBox.Show(cbxProveedor.SelectedValue.ToString());
            

            if (Validar())
            {
                producto.IdProducto = txtIdProducto.Text;
                producto.Nombre = txtNombreProducto.Text;
                producto.Categoria = Convert.ToInt32(cbxCategoria.SelectedValue);
                producto.Año = txtAño.Text;
                producto.Proveedor = Convert.ToInt32(cbxProveedor.SelectedValue);
                producto.Marca = txtMarca.Text;

                if (producto.Guardar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = t1;
                    dataGridView2.Refresh();
                    Cargar_Datos();

                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", producto.Error.ToString()), "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtIdProducto.Text == "")
            {
                MessageBox.Show("Escriba el codigo del producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdProducto.Focus();
                r = false;
            }
              if (txtNombreProducto.Text == "")
            {
                MessageBox.Show("Escriba el nombre del producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                r = false;
            }
            
            if (producto.BuscarIdProducto(txtIdProducto.Text))
            {
                MessageBox.Show(string.Format("Ya existe el codigo del Producto\n{0}\t{1}", producto.IdProducto, producto.Nombre));
                r = false;
            }
            else if (producto.BuscarProducto(txtNombreProducto.Text))
            {
                MessageBox.Show(string.Format("Ya existe el nombre del Producto\n{0}\t{1}", producto.IdProducto, producto.Nombre));

                r = false;
            }
            else
                r = true;
            return r;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                producto.IdProducto = txtIdProducto.Text;
                producto.Nombre = txtNombreProducto.Text;
                producto.Categoria = Convert.ToInt32(cbxCategoria.SelectedValue);
                producto.Año = txtAño.Text;
                producto.Proveedor = Convert.ToInt32(cbxProveedor.SelectedValue);
                producto.Marca = txtMarca.Text;

                if (producto.ModificarProducto())
                {
                    MessageBox.Show("Registro actulizado correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t1 = productos.SQL(String.Format("SELECT idProducto, nombre, categoria, marca, año, proveedor FROM taller.producto"));
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = t1;
                    dataGridView2.Refresh();
                    Cargar_Datos();
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", producto.Error.ToString()), "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                limpiar();
            }
        }


        private Boolean ValidarModificar()
        {
            Boolean r = true;
            if (txtIdProducto.Text == "")
            {
                MessageBox.Show("Escriba el codigo del producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdProducto.Focus();
                r = false;
            }
            else if (txtNombreProducto.Text == "")
            {
                MessageBox.Show("Escriba el nombre del Producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                r = false;
            }
            else if (!producto.BuscarIdProducto(txtIdProducto.Text))
            {
                MessageBox.Show(string.Format("No existe el codigo del Producto\n{0}\t{1}", producto.IdProducto, producto.Nombre));
                r = false;
            }

            else if (producto.BuscarProducto(txtNombreProducto.Text))
            {
                MessageBox.Show(string.Format("Ya existe el nombre del Producto\n{0}\t{1}", producto.IdProducto, producto.Nombre));

                r = false;
            }

            /*else if (producto.BuscarProducto(txtNombreProducto.Text))
            {
                if (MessageBox.Show(string.Format("Ya existe el nombre del Producto con este nombre\n{0}\t{1}\n¿Desea Continuar?", producto.IdProducto, producto.Nombre), 
                    "Modificar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    r = true;
                }
                else
                {
                    r = false;
                }
            }*/

            else
                r = true;
            return r;
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdProducto.Enabled = false;
            txtIdProducto.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtNombreProducto.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cbxCategoria.SelectedValue = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtMarca.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtAño.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            cbxProveedor.SelectedValue = dataGridView2.CurrentRow.Cells[5].Value.ToString();

        }
    }
}
