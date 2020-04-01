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
        private Clases.ClaListaInventario elinventario;
        private ClaInventario inventario;
        public Inventario()
        {
            InitializeComponent();
            c = new ClaConexion();
            elinventario= new Clases.ClaListaInventario();
            inventario = new ClaInventario();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            DataTable t1 = elinventario.SQL(String.Format("SELECT idInventario, producto, existencia, precio FROM taller.inventario "));

            /*DataTable t1 = elinventario.SQL(String.Format("SELECT inv.idInventario,inv.producto, pro.nombre," +
                " cat.nombre AS categoria, pro.marca, pro.año, inv.existencia, inv.precio FROM taller.inventario As inv INNER JOIN taller.producto AS pro" +
                "ON inv.producto = pro.idProducto INNER JOIN taller.categoria AS cat" +
                "ON pro.categoria = cat.idCategoria "));*/

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
