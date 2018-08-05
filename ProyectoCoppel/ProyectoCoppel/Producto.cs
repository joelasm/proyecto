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
    public partial class Producto : Form
    {
        C_Producto c_prod = new C_Producto();
        bool validacion;
        int poc;
        int retorno;
        public Producto()
        {
            InitializeComponent();
            llenar_cmb();
            tabla_productos();
            limpiar();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validar();
            if (validacion)
            {
                retorno = c_prod.Ins_proveedor(txtDesc.Text, cmbEstatus.SelectedValue.ToString());
                if(retorno >0)
                {
                    tabla_productos();
                    limpiar();
                }
            }

        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorP.SetError(txtDesc, "");
            poc = dgvProductos.CurrentRow.Index;
            txtDesc.Text = dgvProductos[1, poc].Value.ToString();
            cmbEstatus.SelectedValue = dgvProductos[2, poc].Value.ToString();
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnnuevo.Enabled = true;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            tabla_productos();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            validar();
            if (validacion)
            {
                DialogResult result = MessageBox.Show("Desea actualizar el producto", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvProductos[0, poc].Value.ToString());
                    retorno = c_prod.Act_Producto(txtDesc.Text, cmbEstatus.SelectedValue.ToString(), id);
                    if (retorno > 0)
                    {
                        limpiar();
                        tabla_productos();
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Eliminar el producto", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                c_prod.Elm_Producto(Convert.ToInt32(dgvProductos[0, poc].Value.ToString()));
                tabla_productos();
                limpiar();
            }
        }

        #region Metodo para llenar un combobox
        public void llenar_cmb()
        {
            
            cmbEstatus.DataSource = c_prod.cmb_Estatus();
            cmbEstatus.ValueMember = "id";
            cmbEstatus.DisplayMember = "Descripcion";
        }
        #endregion

        #region Metodo para llenar el datagridview
        public void tabla_productos()
        {
            dgvProductos.DataSource = c_prod.llenar_dgv();
        }
        #endregion.

        #region Metodo para validar los campos vacios
        public void validar()
        {
            validacion = true;
            if (txtDesc.Text == "")
            {
                errorP.SetError(txtDesc, "ingrese una descripcion");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtDesc, "");
            }
           
        }
        #endregion

        #region Metodo para limpiar
        public void limpiar()
        {
            errorP.SetError(txtDesc, "");
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnnuevo.Enabled = false;
            txtDesc.Text = "";
            cmbEstatus.SelectedIndex = 0;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;

        }
        #endregion

       
    }
}
