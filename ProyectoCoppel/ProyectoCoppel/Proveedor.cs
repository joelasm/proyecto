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
    public partial class Proveedor : Form
    {
        C_Proveedor c_prov = new C_Proveedor();
        bool validacion;
        int poc;
        int retorno;

        public Proveedor()
        {
            InitializeComponent();
            tabla_proveedores();
            llenar_cmb();
            limpiar();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validar();
            if (validacion)
            {
                retorno = c_prov.Ins_proveedor(txtRfc.Text, txtNombre.Text, cmbEstatus.SelectedValue.ToString());
                if (retorno > 0)
                {
                    tabla_proveedores();
                    limpiar();
                }
            }
          
        }
        
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            tabla_proveedores();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            validar();
            if (validacion)
            {
                DialogResult result = MessageBox.Show("Desea Actualizar el proveedor", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvProveedor[0, poc].Value.ToString());
                    c_prov.Act_Proveedor(id, txtRfc.Text, txtNombre.Text, cmbEstatus.SelectedValue.ToString());
                    tabla_proveedores();
                    limpiar();
                }
            }
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorP.SetError(txtNombre, "");
            errorP.SetError(txtRfc, "");
            poc = dgvProveedor.CurrentRow.Index;
            txtRfc.Text = dgvProveedor[1, poc].Value.ToString();
            txtNombre.Text = dgvProveedor[2, poc].Value.ToString();
            cmbEstatus.SelectedValue = dgvProveedor[3, poc].Value.ToString();
           
          
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnnuevo.Enabled = true;
            
        }
       

        #region Metodo para llenar el datagridview
        public void tabla_proveedores()
        {
           dgvProveedor.DataSource = c_prov.llenar_dgv();
        }
        #endregion.

        #region Metodo para llenar un combobox de Estatus
        public void llenar_cmb()
        {

            cmbEstatus.DataSource = c_prov.cmb_proveedores();
            cmbEstatus.ValueMember = "id";
            cmbEstatus.DisplayMember = "Descripcion";
        }
        #endregion

        #region Metodo para validar los campos vacios
        public void validar()
        {
            validacion = true;
            if (txtRfc.Text == "")
            {
                errorP.SetError(txtRfc, "Ingrese un RFC");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtRfc, "");
            }
            if (txtNombre.Text == "")
            {
                errorP.SetError(txtNombre, "Ingrese un Nombre");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtNombre, "");
            }
        }
        #endregion

        #region Metodo para limpiar
        public void limpiar()
        {
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnnuevo.Enabled = false;
            txtNombre.Text = "";
            txtRfc.Text = "";
            cmbEstatus.SelectedIndex = 0;
            dgvProveedor.AllowUserToAddRows = false;
            dgvProveedor.MultiSelect = false;
            dgvProveedor.ReadOnly = true;

        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Eliminar el proveedor", "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                c_prov.Elm_Proveedor(Convert.ToInt32(dgvProveedor[0, poc].Value.ToString()));
                tabla_proveedores();
                limpiar();
            }
            
        }
    }
}
