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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.Show();
            this.Close();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Producto prod = new Producto();
            prod.Show();
            this.Close();
        }
        
        private void comentariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comentarios_usuario com = new Comentarios_usuario();
            com.Show();
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Salir", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Properties.Settings.Default.Usuario = "";
                Login log = new Login();
                log.Show();
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Usuario R_Usuario = new Registrar_Usuario("Menu");
            R_Usuario.Show();
            this.Close();
        }

        private void proveedorProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prov_Prod provedor_prodcto = new Prov_Prod();
            provedor_prodcto.Show();
            this.Close();
        }
    }
}
