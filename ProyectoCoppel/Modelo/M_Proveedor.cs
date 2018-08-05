using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
   public class M_Proveedor: clsVariables
    {
        int retorno;


        #region Metodo para insertar un proveedor
        public int insertar()
        {

            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("insert into tblProveedores (RFC,nombre,Estatus) values('{0}','{1}','{2}')", this.rfc, this.nombre, this.estatus), conn);
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

        #region metodo para seleccionar todos los proveedores
        public DataTable mostra_Proveedor()
        {
            DataSet dsproveedor = new DataSet();
            using (SqlConnection conn = clsConexion.conectar())
            {
                SqlDataAdapter daproveedor = new SqlDataAdapter("select *from tblProveedores", conn);
                daproveedor.Fill(dsproveedor, "proveedor");
                return dsproveedor.Tables[0];
            }

        }

        #endregion

        #region metodo para actualizar proveedor
        public int Actualizar_proveedor()
        {

            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(String.Format("update tblProveedores set RFC='{0}',  nombre='{1}', Estatus='{2}' where ProveedorId={3} and Not ProveedorId In(select ProveedorId from tblProveedorProducto)", this.rfc, this.nombre, this.estatus, this.id), conn);
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

        #region Metodo para eliminar Proveedor
        public int Eliminar_Proveedor()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("delete from tblProveedores where ProveedorId={0} ", this.id), conn);
                    retorno = comando.ExecuteNonQuery();                    
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

    }
}
