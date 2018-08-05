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
    public partial class Login : Form
    {
        int retorno;
        bool validacion;
        C_usuario C_usu = new C_usuario();
        C_Validacion c_Validar = new C_Validacion();
        public Login()
        {
            InitializeComponent();
            txtClave.MaxLength = 3;
            txtClave.PasswordChar = '*';
        }
        
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            validar();
            if (validacion)
            {
                retorno = C_usu.buscar_usuario(Convert.ToInt32(txtUsuario.Text), txtClave.Text,1);
                if (retorno > 0)
                {
                    
                    Menu M = new Menu();
                    Properties.Settings.Default.Usuario =txtUsuario.Text;
                    this.Hide();
                    M.Show();

                }
                else
                {
                    MessageBox.Show("El usuario no esta activado, o no se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Text = "";
                    txtUsuario.Text = "";
                }
            }
        }

        private void link_registrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registrar_Usuario Reg_usuario = new Registrar_Usuario("login");
            Reg_usuario.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            c_Validar.validar_usuario(e);
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            c_Validar.Validar_Clave(e);
        }

        #region Metodo para validar textbox
        public void validar()
        {
            validacion = true;
            if (txtUsuario.Text == "")
            {
                errorP.SetError(txtUsuario, "Ingrese un usuario");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtUsuario, "");
            }
            if (txtClave.Text == "")
            {
                errorP.SetError(txtClave, "Ingrese una clave");
                validacion = false;
            }
            else
            {
                errorP.SetError(txtClave, "");
            }

        }

        #endregion

        
    }
}
