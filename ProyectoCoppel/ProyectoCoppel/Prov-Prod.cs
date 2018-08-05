using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
namespace ProyectoCoppel
{
    public partial class Prov_Prod : Form
    {
        C_proveedor_producto c_prov_prod = new C_proveedor_producto();
        int retorno;
        int poc;
        public Prov_Prod()
        {
            InitializeComponent();
            Mostrar_Proveedores();
            Mostrar_Productos();
            mostrar_prov_prod();
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedIndex > -1 && cmbProveedor.SelectedIndex >-1)
            {
                int idprov = Convert.ToInt32(cmbProveedor.SelectedValue.ToString());
                int idprod = Convert.ToInt32(cmbProductos.SelectedValue.ToString());
                retorno = c_prov_prod.Ins_prov_prod(idprov, idprod);
                if (retorno > 0)
                {
                    limpiar();
                    Mostrar_Productos();
                    mostrar_prov_prod();
                }
            }
            else
            {
                MessageBox.Show("verifique si ahi proveedores o productos agregados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Desea eliminar el Registro", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                int idprov =Convert.ToInt32(dgvprov_prod[0,poc].Value.ToString());
                int idprod = Convert.ToInt32(dgvprov_prod[2, poc].Value.ToString());
                c_prov_prod.Eliminar_Registro(idprov,idprod);
                Mostrar_Productos();
                mostrar_prov_prod();
                limpiar();
            }
        }

        private void dgvprov_prod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = dgvprov_prod.CurrentRow.Index;
            cbProveedor.Visible = true;
            if (cmbProductos.SelectedIndex >= 0)
            {
                cbProducto.Visible = true;
            }
            cmbProveedor.Enabled = false;
            cmbProductos.Enabled = false;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void cbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProveedor.Checked)
            {
                cmbProveedor.Enabled = true;
                btnActualizar.Enabled = true;
            }
            else
            {
                cmbProveedor.Enabled = false;
            }
            if (cbProveedor.Checked == false && cbProducto.Checked == false)
            {
                btnActualizar.Enabled = false;
            }
        }

        private void cbProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProducto.Checked)
            {
                cmbProductos.Enabled = true;
                btnActualizar.Enabled = true;
            }
            else
            {
                cmbProductos.Enabled = false;
            }
            if (cbProveedor.Checked == false && cbProducto.Checked == false)
            {
                btnActualizar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea actualizar el registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvprov_prod[2, poc].Value.ToString());
                int idprov = 0;
                int idprod = 0;
                if (cbProducto.Checked == true && cbProveedor.Checked == false)
                {
                    idprov = Convert.ToInt32(dgvprov_prod[0, poc].Value.ToString());
                    idprod = Convert.ToInt32(cmbProductos.SelectedValue.ToString());
                    c_prov_prod.Act_registro(idprov, idprod, id);


                }
                if (cbProveedor.Checked == true && cbProducto.Checked == false)
                {
                    idprov = Convert.ToInt32(cmbProveedor.SelectedValue.ToString());
                    idprod = Convert.ToInt32(dgvprov_prod[2, poc].Value.ToString());
                    c_prov_prod.Act_registro(idprov, idprod, id);
                }
                if (cbProveedor.Checked == true && cbProducto.Checked == true)
                {
                    idprov = Convert.ToInt32(cmbProveedor.SelectedValue.ToString());
                    idprod = Convert.ToInt32(cmbProductos.SelectedValue.ToString());
                    c_prov_prod.Act_registro(idprov, idprod, id);
                }
                mostrar_prov_prod();
                Mostrar_Productos();
                limpiar();
            }
            
          

        }

        #region Metodo para mostrar el combobox de proveedores
        public void Mostrar_Proveedores()
        {
            cmbProveedor.DataSource = c_prov_prod.Mostrar_proveedoractivo();
            cmbProveedor.ValueMember = "ProveedorId";
            cmbProveedor.DisplayMember = "nombre";
        }
        #endregion

        #region Metodo para mostrar el combobox de proveedores
        public void Mostrar_Productos()
        {
            cmbProductos.DataSource = c_prov_prod.MostrarProductos();
            cmbProductos.ValueMember = "ProductoId";
            cmbProductos.DisplayMember = "Descripcion";
        }
        #endregion

        #region Metodo para mostrar la tabla proveedores-productos en datagridview
        public void mostrar_prov_prod()
        {
            dgvprov_prod.DataSource = c_prov_prod.Mostrar_prov_prod();
            dgvprov_prod.Columns[0].Width = 40;
            dgvprov_prod.Columns[1].Width = 150;
            dgvprov_prod.Columns[2].Width = 40;
            dgvprov_prod.Columns[3].Width = 150;
        }
        #endregion

        #region Metodo para limpiar
        public void limpiar()
        {
            
            cbProveedor.Visible = false;
            cbProducto.Checked = false;
            cbProveedor.Checked = false;
            cbProducto.Visible = false;
            dgvprov_prod.AllowUserToAddRows = false;
            dgvprov_prod.MultiSelect = false;
            dgvprov_prod.ReadOnly = true;   
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
            btnGuardar.Enabled = true;
            if (cmbProductos.SelectedIndex > -1)
            {
                cmbProductos.SelectedIndex = 0;
            }
            if (cmbProveedor.SelectedIndex > -1)
            {
                cmbProveedor.SelectedIndex = 0;
            }
            cmbProductos.Enabled = true;
            cmbProveedor.Enabled = true;

        }



        #endregion

        
    }
}
