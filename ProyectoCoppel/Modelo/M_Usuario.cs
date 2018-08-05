using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Modelo
{
    public class M_Usuario : clsVariables
    {
        int retorno;
        #region Metodo para insertar un Usuario
        public int insertar_Usuario()
        {

            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("insert into tblUsuarios (Clave,Nombre,Apellido,Fecha_N,Estatus) values('{0}','{1}','{2}','{3}','{4}')", this.Clave, this.nombre, this.apellido, this.fecha, this.estatus), conn);
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

        #region Metodo para seleccionar el id
        public string Sel_idusiario()
        {
            string id;
            using (SqlConnection conn = clsConexion.conectar())
            {
                SqlCommand comando = new SqlCommand(string.Format(" Select Max (UsuarioId) as UsuarioId from tblUsuarios"), conn);
                SqlDataReader dr_id = comando.ExecuteReader();
                dr_id.Read();
                id = dr_id["UsuarioId"].ToString();
                conn.Dispose();
                conn.Close();
            }
            return id;
        }
        #endregion

        #region Metodo para seleccionar un usuario
        public DataTable Sel_usuario()
        {
            DataSet dsusuario = new DataSet();


            using (SqlConnection conn = clsConexion.conectar())
            {
                    SqlDataAdapter damateria = new SqlDataAdapter(string.Format(" Select Nombre,Apellido,Fecha_N,Estatus from tblUsuarios where UsuarioId={0} and Clave='{1}'", this.id, this.Clave), conn);
                    damateria.Fill(dsusuario, "proveedor");
                    return dsusuario.Tables[0];
            }

        }
        #endregion

        #region Metodo para buscar
        public int Buscar_usuario()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                if (opc_busqueda == 1)
                {

                    SqlCommand comando = new SqlCommand(string.Format("Select *from tblUsuarios where UsuarioId={0} and Clave='{1}' and Estatus='true'", this.id, this.Clave), conn);
                    retorno = Convert.ToInt32(comando.ExecuteScalar());

                }
                else
                {
                    
                    SqlCommand comando = new SqlCommand(string.Format("Select *from tblUsuarios where UsuarioId={0} and Clave='{1}'", this.id, this.Clave), conn);
                    retorno = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            return retorno;
        }
        #endregion

        #region Metodo para Actualizar_clave
        public int Act_Clave()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(String.Format("update tblUsuarios set Clave='{0}' where UsuarioId={1} and Clave='{2}'", this.NClave, this.id, this.Clave), conn);
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

        #region Metodo para Actualizar_datos
        public int Act_Datos()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {

                    SqlCommand comando = new SqlCommand(String.Format("update tblUsuarios set Nombre='{0}',Apellido = '{1}',Fecha_N = '{2}',Estatus = '{3}' where UsuarioId = {4} and Clave = '{5}'", this.nombre, this.apellido, this.fecha, this.estatus, this.id, this.Clave), conn);
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

        #region Metodo para eliminar Usuario
        public int Elim_usuario()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("delete from tblUsuarios where UsuarioId={0} and Clave='{1}'", this.id, this.Clave), conn);
                    retorno = comando.ExecuteNonQuery();
                    conn.Dispose();
                    conn.Close();
                }
                catch
                {
                    retorno = 2;
                }
            }

                return retorno;
        }
        #endregion

    }
}
