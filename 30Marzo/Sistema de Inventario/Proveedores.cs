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
    public partial class Proveedores : Form
    {
        ClaConexion c;
        private Clases.ClaListaProveedores proveedores;
        private Clases.ClaProveedor proveedor;
        public Proveedores()
        {
            InitializeComponent();
            c = new ClaConexion();
            proveedores = new Clases.ClaListaProveedores();
            proveedor = new Clases.ClaProveedor();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            DataTable t1 = proveedores.SQL(String.Format("SELECT idProveedor, RTNProveedor, nombre, telefono, " +
                "direccion, correoElectronico FROM taller.proveedor"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();

        }

        private void Cargar_Datos()
        {
            txtIdProveedor.Text = proveedor.p.ToString();
            txtRTN.Text = proveedor.r;
            txtNombreProveedor.Text = proveedor.n;
            txtTelefono.Text = proveedor.t;
            txtDireccion.Text = proveedor.d;
            txtCorreo.Text = proveedor.c;
            txtIdProveedor.Focus();
            SendKeys.Send("{Tab}");
        }
        private void limpiar()
        {
            txtIdProveedor.Text = "";
            txtRTN.Text = "";
            txtNombreProveedor.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtIdProveedor.Enabled = true;
            txtIdProveedor.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                //proveedor.p = Convert.ToInt32(txtIdProveedor.Text);
                proveedor.r = txtRTN.Text;
                proveedor.n = txtNombreProveedor.Text;
                proveedor.t = txtTelefono.Text;
                proveedor.d = txtDireccion.Text;
                proveedor.c = txtCorreo.Text;
                
                if (proveedor.Guardar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t1 = proveedores.SQL(String.Format("SELECT idProveedor, RTNProveedor, nombre, telefono, " +
                                "direccion, correoElectronico FROM taller.proveedor"));
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = t1;
                    dataGridView2.Refresh();
                    Cargar_Datos();

                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", proveedor.Error.ToString()), "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
             if (txtNombreProveedor.Text == "")
            {
                MessageBox.Show("Escriba el nombre del Proveedor", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProveedor.Focus();
                r = false;
            }
            
            if (proveedor.BuscarIdProveedor(txtIdProveedor.Text))
            {
                MessageBox.Show(string.Format("Ya existe el codigo del Proveedor\n{0}\t{1}", proveedor.p, proveedor.n));
                r = false;
            }
            else if (proveedor.BuscarProveedor(txtNombreProveedor.Text))
            {
                MessageBox.Show(string.Format("Ya existe el nombre del Proveedor\n{0}\t{1}", proveedor.p, proveedor.n));

                r = false;
            }
            else
                r = true;
            return r;

        }
    }
}
