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
    public partial class Comentarios_usuario : Form
    {
        C_Comentarios C_com = new C_Comentarios();
        bool Validacion;
        int retorno;
        int poc;
        public Comentarios_usuario()
        {
            InitializeComponent();

            Mostrar_comentarios();
            mostrar_todosComentario();
            llenar_cmb();            
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Validar();
            if (Validacion)
            {
                retorno = C_com.Ins_comentario(txtDescripcion.Text, Convert.ToInt32(Properties.Settings.Default.Usuario), cmbEstatus.SelectedValue.ToString());
                if (retorno > 0)
                {
                    mostrar_todosComentario();
                    Mostrar_comentarios();
                    limpiar();
                }
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu M = new Menu();
            M.Show();
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Validar();
            if(Validacion)
            {
                DialogResult result = MessageBox.Show("Desea actualizar el Comentario", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvComentarios[0, poc].Value.ToString());
                    C_com.Act_Comentario(id, txtDescripcion.Text, cmbEstatus.SelectedValue.ToString());
                    Mostrar_comentarios();
                    mostrar_todosComentario();
                    limpiar();
                }
            }
        }

        private void dgvComentarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = dgvComentarios.CurrentRow.Index;
            txtDescripcion.Text = dgvComentarios[1, poc].Value.ToString();
            cmbEstatus.SelectedValue = dgvComentarios[2, poc].Value.ToString();
            errorP.SetError(txtDescripcion, "");
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Desea eliminar el Comentario", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if(Resultado==DialogResult.Yes)
            {
                C_com.Elm_Comentrio(Convert.ToInt32(dgvComentarios[0,poc].Value.ToString()));
                limpiar();
                Mostrar_comentarios();
                mostrar_todosComentario();
            }
        }

        
        #region Metodo para llenar un combobox de Estatus
        public void llenar_cmb()
        {

            cmbEstatus.DataSource = C_com.cmb_Comentario();
            cmbEstatus.ValueMember = "id";
            cmbEstatus.DisplayMember = "Descripcion";
        }
        #endregion
        #region Metodo Para validar los comentarios
        public void Validar()
        {
            Validacion = true;
            if (txtDescripcion.Text == "")
            {
                errorP.SetError(txtDescripcion, "Ingrese un comentario");
                Validacion = false;
            }
            else
            {
                errorP.SetError(txtDescripcion, "");
            }
        }
        #endregion
        #region Metodo para limpiar
        public void limpiar()
        {
            dgvComentarios.AllowUserToAddRows = false;
            dgvComentarios.MultiSelect = false;
            dgvComentarios.ReadOnly = true;
            dgvTodosComentarios.Columns["Usuario"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvTodosComentarios.AllowUserToAddRows = false;
            dgvTodosComentarios.MultiSelect = false;
            dgvTodosComentarios.ReadOnly = true;
            dgvTodosComentarios.Columns["Comentario"].SortMode = DataGridViewColumnSortMode.NotSortable;

            txtDescripcion.Text = "";
            cmbEstatus.SelectedIndex = 0;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
        }
        #endregion
        #region Metodo para llenar dgv de los comentarios por el usuario
        public void Mostrar_comentarios()
        {

            dgvComentarios.DataSource = C_com.llenar_dgv(Convert.ToInt32(Properties.Settings.Default.Usuario));
            dgvComentarios.Columns[0].Width = 30;
            dgvComentarios.Columns[1].Width = 299;
            dgvComentarios.Columns[2].Width = 44;
        }
        #endregion
        #region Metodo para llenar dgv de todos los comentarios
        public void mostrar_todosComentario()
        {
            dgvTodosComentarios.DataSource = C_com.llenar_comentarios();
            dgvTodosComentarios.Columns[0].Width = 150;
            dgvTodosComentarios.Columns[1].Width = 299;
        }
        #endregion
    }
}
