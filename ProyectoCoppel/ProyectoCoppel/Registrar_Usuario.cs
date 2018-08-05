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
    public partial class Registrar_Usuario : Form
    {
        C_usuario C_us = new C_usuario();
        C_Validacion c_validar = new C_Validacion();
        bool validacion;
        int retorno;
        string id;
        string opcion;

        public Registrar_Usuario(string opc)
        {
            InitializeComponent();
            llenar_cmb();
            limpiar();
            txtClave.MaxLength = 3;
            txtRClave.MaxLength = 3;
            txtClave.PasswordChar = '*';
            txtRClave.PasswordChar = '*';
            opcion = opc;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validar();
            if(validacion)
            {
                string fecha = dtpUsuario.Value.ToString("yyyy/MM/dd");
                retorno = C_us.Ins_usuario(txtClave.Text, txtRClave.Text, txtNombre.Text, txtApellido.Text, fecha, cmbEstatus.SelectedValue.ToString());
                if(retorno>0)
                {
                    limpiar();
                    id = C_us.sel_id();
                    MessageBox.Show("Su usuario es: " + id, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (opcion == "login")
            {
                Login log = new Login();
                log.Show();
                this.Close();
               
            }
            else
            if(opcion=="Menu")
            {
                Menu m = new Menu();
                m.Show();
                this.Close();

            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar_usuario Act_usurio = new Actualizar_usuario(opcion);
            Act_usurio.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar_usuario Elim_usuario = new Eliminar_usuario(opcion);
            Elim_usuario.Show();
            this.Close();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            c_validar.Validar_Clave(e);
        }

        private void txtRClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            c_validar.Validar_Clave(e);
        }

        #region Metodo para validar los campos vacios
        public void validar()
        {
            validacion = true;
            if (txtClave.Text == "")
            {
                errorP.SetError(txtClave, "Ingrese una clave");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtClave, "");
            }

            if (txtRClave.Text == "")
            {
                errorP.SetError(txtRClave, "Repita la clave");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtRClave, "");
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
            if (txtApellido.Text == "")
            {
                errorP.SetError(txtApellido, "Ingrese un Apellido");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtApellido, "");
            }


        }
        #endregion

        #region Metodo para limpiar
        public void limpiar()
        {
            txtClave.Text = "";
            txtRClave.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpUsuario.Value = DateTime.Now;
            cmbEstatus.SelectedIndex = 0;
        }
        #endregion

        #region Metodo para llenar un combobox de Estatus
        public void llenar_cmb()
        {

            cmbEstatus.DataSource = C_us.cmb_Usuario();
            cmbEstatus.ValueMember = "id";
            cmbEstatus.DisplayMember = "Descripcion";
        }

        #endregion

        
    }
}
