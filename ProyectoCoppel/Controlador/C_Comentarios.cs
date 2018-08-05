using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Modelo;


namespace Controlador
{
    public class C_Comentarios
    {
        M_Comentarios M_com = new M_Comentarios();
        int retorno;
       
        #region Metodo insertar Comentario
        public int Ins_comentario(string descripcion, int id,string estado)
        {
            M_com.descripcion = descripcion;
            M_com.id = id;
            M_com.estatus = estado;
            retorno = M_com.insertar_Comentario();
            if (retorno > 0)
            {
                MessageBox.Show("Se guardo con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No se Guardo el Comentario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }
        #endregion

        #region Metodo para actualizar Comentario
        public void Act_Comentario(int id, string descripcion, string estado)
        {

            M_com.id = id;
            M_com.descripcion = descripcion;
            M_com.estatus= estado;
            retorno = M_com.Actualizar_comentario();
            if (retorno > 0)
            {
                MessageBox.Show("Se Actualizo con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("EL comentario no se pudo actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Metodo para mandar tabla de comentarios por usuario
        public DataTable llenar_dgv(int id)
        {
            M_com.id = id;
            DataTable dt = M_com.mostra_Comentarios();

            return dt;
        }
        #endregion

        #region Metodo para mandar tabla de todo los comentarios
        public DataTable llenar_comentarios()
        {
            DataTable dt = M_com.Todo_comentarios();

            return dt;
        }
        #endregion

        #region Metodo para eliminar comentario
        public void Elm_Comentrio(int id)
        {
            M_com.id = id;
            retorno = M_com.Eliminar_Comentario();
            if(retorno>0)
            {
                MessageBox.Show("EL comentario Fue eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Metodo para llenar combobox
        public DataTable cmb_Comentario()
        {
            DataTable dt;
            dt = new DataTable("Tabla");

            dt.Columns.Add("id");
            dt.Columns.Add("Descripcion");

            DataRow dr;
            dr = dt.NewRow();
            dr[0] = "True";
            dr[1] = "Activo";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "False";
            dr[1] = "Inactivo";
            dt.Rows.Add(dr);
            return dt;
        }
        #endregion

    }
}
