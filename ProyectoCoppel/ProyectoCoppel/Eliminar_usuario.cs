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
    public partial class Eliminar_usuario : Form
    {
        C_usuario C_usu = new C_usuario();
        C_Validacion c_Validar = new C_Validacion();
        Login log = new Login();
        Menu m = new Menu();
        string opcion;
        int retorno;
        public Eliminar_usuario(string opc)
        {
            InitializeComponent();
            txtclave.MaxLength = 3;
            txtclave.PasswordChar = '*';
            opcion = opc;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           DialogResult Resultado= MessageBox.Show("Desea eliminar el usuario", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {

                retorno = C_usu.Elim_usuario(Convert.ToInt32(txtUsuario.Text), txtclave.Text);
                if (retorno == 1)
                {
                    if (Properties.Settings.Default.Usuario == txtUsuario.Text)
                    {
                        Properties.Settings.Default.Usuario = "";
                        this.Visible = false;
                        log.Visible = true;

                    }
                  
                }
                    txtUsuario.Text = "";
                    txtclave.Text = "";
              
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Registrar_Usuario reg_usuario = new Registrar_Usuario(opcion);
            reg_usuario.Visible = true;
            this.Visible = false;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {

            c_Validar.validar_usuario(e);
        }

        private void txtclave_KeyPress(object sender, KeyPressEventArgs e)
        {
            c_Validar.Validar_Clave(e);
        }
    }
}
