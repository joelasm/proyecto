using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Controlador;

namespace ProyectoCoppel
{
    public partial class Actualizar_usuario : Form
    {
        C_usuario C_usu = new C_usuario();
        C_Validacion c_validar = new C_Validacion();
        int retorno;
        bool validacion;
        string opcion;
        public Actualizar_usuario(string opc)
        {
            InitializeComponent();
            txtClave.MaxLength = 3;
            txtNclave.MaxLength = 3;
            txtRNclave.MaxLength = 3;
            txtClave.PasswordChar = '*';
            txtNclave.PasswordChar = '*';
            txtRNclave.PasswordChar = '*';
            Llenar_cmb();
            limpiar();
            opcion = opc;
        }

        private void cbClave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClave.Checked)
            {
                txtNclave.Enabled = true;
                txtRNclave.Enabled = true;
                btnActualizar.Enabled = true;
            }
            else
            {
                txtNclave.Enabled = false;
                txtRNclave.Enabled = false;
            }
            if (cbDatos.Checked == false && cbClave.Checked == false)
            {
                btnActualizar.Enabled = false;
            }
        }

        private void cbDatos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDatos.Checked)
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                dtpUsuario.Enabled = true;
                cmbEstatus.Enabled = true;
                btnActualizar.Enabled = true;

            }
            else
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                dtpUsuario.Enabled = false;
                cmbEstatus.Enabled = false;
            }

            if(cbDatos.Checked==false && cbClave.Checked==false)
            {
                btnActualizar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea actualizar el Usuario", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (cbClave.Checked)
                {
                    if (txtNclave.Text != "" && txtRNclave.Text != "")
                    {
                        if (txtNclave.Text == txtRNclave.Text)
                        {
                            C_usu.Act_Clave(Convert.ToInt32(txtUsuario.Text), txtClave.Text, txtNclave.Text);
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Porfavor verifique que la contraseña coincida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Porfavor verifique si ingreso una nueva contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (cbDatos.Checked)
                {

                    string fecha = dtpUsuario.Value.ToString("yyyy/MM/dd");
                    C_usu.Act_Datos(Convert.ToInt32(txtUsuario.Text), txtClave.Text, txtNombre.Text, txtApellido.Text, fecha, cmbEstatus.SelectedValue.ToString());
                    if (cmbEstatus.SelectedValue.ToString() == "False" && opcion == "Menu")
                    {
                        Login log = new Login();
                        log.Show();
                        this.Close();

                    }
                    limpiar();
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            validar();
            if (validacion)
            {
                retorno = C_usu.buscar_usuario(Convert.ToInt32(txtUsuario.Text), txtClave.Text,2);
                if (retorno > 0)
                {
                    DataTable dt_usu = C_usu.dt_usuario(Convert.ToInt32(txtUsuario.Text), txtClave.Text);
                    txtNombre.Text = dt_usu.Rows[0].ItemArray[0].ToString();
                    txtApellido.Text = dt_usu.Rows[0].ItemArray[1].ToString();
                    string fecha = dt_usu.Rows[0].ItemArray[2].ToString();
                    fecha = fecha.Substring(0, 10);
                    dtpUsuario.Value = Convert.ToDateTime(fecha);
                    cmbEstatus.SelectedValue = dt_usu.Rows[0].ItemArray[3].ToString();
                    txtClave.Enabled = false;
                    txtUsuario.Enabled = false;
                    btnCancelar.Enabled = true;
                    cbClave.Enabled = true;
                    cbDatos.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El usuario y/o la contraseña son incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        
        private void btnSAlir_Click(object sender, EventArgs e)
        {
           
            
                Registrar_Usuario reg_usuario = new Registrar_Usuario(opcion);
                reg_usuario.Visible = true;
                this.Visible = false;
        }

        #region metodo para llenar combobox de estatus

        public void Llenar_cmb()
        {
            cmbEstatus.DataSource = C_usu.cmb_Usuario();
            cmbEstatus.ValueMember = "id";
            cmbEstatus.DisplayMember = "Descripcion";
        }
        #endregion

        #region Metodo de limpiesa
        public void limpiar()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            txtNclave.Text = "";
            txtNombre.Text = "";
            txtRNclave.Text = "";
            txtApellido.Text = "";
            cmbEstatus.SelectedValue = "True";
            dtpUsuario.Value = DateTime.Now;
            cbClave.Checked = false;
            cbDatos.Checked = false;
            cbClave.Enabled = false;
            cbDatos.Enabled = false;
            txtUsuario.Enabled = true;
            txtClave.Enabled = true;
            btnCancelar.Enabled = false;

        }
        #endregion

        #region Metodo para Validar usuario y clave
        public void validar()
        {
            validacion = true;
            if (txtUsuario.Text == "")
            {
                errorP.SetError(txtUsuario, "Ingrese el usuario");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtUsuario, "");
            }

            if (txtClave.Text == "")
            {
                errorP.SetError(txtClave, "ingrese una clave");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtClave, "");
            }


        }

        #endregion

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            c_validar.validar_usuario(e);
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            c_validar.Validar_Clave(e);
        }
    }
}
