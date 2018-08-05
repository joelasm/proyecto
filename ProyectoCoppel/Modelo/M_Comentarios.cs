using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class M_Comentarios : clsVariables
    {
        int retorno;
        #region Metodo para insertar un comentario
        public int insertar_Comentario()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("insert into tblComentarios (Descripcion,UsuarioId,Estatus) values('{0}','{1}','{2}')", this.descripcion, this.id, this.estatus), conn);
                    retorno = comando.ExecuteNonQuery();

                    comando.Dispose();
                }
                catch
                {

                    retorno = 0;
                }
                conn.Dispose();
                conn.Close();
            }
            return retorno;
        }
        #endregion

        #region metodo para seleccionar comentarios de un usuario
        public DataTable mostra_Comentarios()
        {
            DataSet dscomentarios = new DataSet();
            using (SqlConnection conn = clsConexion.conectar())
            {
                SqlDataAdapter dacomentario = new SqlDataAdapter(string.Format("select (ComentarioId) as id, Descripcion, estatus from tblComentarios where UsuarioId={0}", this.id), conn);
                dacomentario.Fill(dscomentarios, "Comentarios");
                return dscomentarios.Tables[0];
            }

        }

        #endregion

        #region metodo para seleccionar todo los comentario
        public DataTable Todo_comentarios()
        {
            DataSet dscomentarios = new DataSet();
            using (SqlConnection conn = clsConexion.conectar())
            {
                SqlDataAdapter dacomentario = new SqlDataAdapter(string.Format(" select us.Nombre +' '+us.Apellido as[Usuario], com.Descripcion as[Comentario] from tblComentarios com inner join tblUsuarios us on com.UsuarioId = us.UsuarioId where com.Estatus ='true' and us.Estatus='true' order by com.ComentarioId desc "), conn);
                dacomentario.Fill(dscomentarios, "Comentarios");
                return dscomentarios.Tables[0];
            }

        }

        #endregion

        #region metodo para actualizar Comentario
        public int Actualizar_comentario()
        {

            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(String.Format("update tblComentarios set Descripcion='{0}',  Estatus='{1}' where ComentarioId={2}", this.descripcion, this.estatus, this.id), conn);
                    retorno = comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                catch
                {
                    retorno = 0;
                }
                conn.Dispose();
                conn.Close();
            }
            return retorno;

        }
        #endregion

        #region Metodo para eliminar Comentario
        public int Eliminar_Comentario()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                SqlCommand comando = new SqlCommand(string.Format("delete from tblComentarios where ComentarioId={0} ", this.id ), conn);
                retorno = comando.ExecuteNonQuery();
                conn.Dispose();
                conn.Close();
            }

            return retorno;
        }
        #endregion



    }
}
