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
    public partial class Inventario : Form
    {
        ClaConexion c;
        private Clases.ClaListaInventario inventario;
        public Inventario()
        {
            InitializeComponent();
            c = new ClaConexion();
            inventario= new Clases.ClaListaInventario();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            DataTable t1 = inventario.SQL(String.Format("SELECT idInventario, producto, existencia, precio FROM taller.inventario"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producto form = new Producto();
            form.Show();
        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores form = new Proveedores();
            form.Show();
        }

        private void agregarCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria form = new Categoria();
            form.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
