using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class M_Producto : clsVariables
    {
        int retorno;

        #region Metodo para insertar un producto
        public int insertar_Producto()
        {

            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("insert into tblProductos (Descripcion,Estatus) values('{0}','{1}')", this.descripcion, this.estatus), conn);
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

        #region metodo para seleccionar todos los productos
        public DataTable mostra_Productos()
        {
            DataSet dsproductos = new DataSet();
            using (SqlConnection conn = clsConexion.conectar())
            {
                SqlDataAdapter daProductos = new SqlDataAdapter("select *from tblProductos", conn);
                daProductos.Fill(dsproductos, "productos");
                conn.Close();
                conn.Dispose();
                return dsproductos.Tables[0];
            }

        }

        #endregion

        #region metodo para actualizar producto
        public int Actualizar_producto()
        {

            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(String.Format("update tblProductos set Descripcion='{0}', Estatus='{1}' where ProductoID={2} and Not ProductoID In(select ProductoID from tblProveedorProducto)", this.descripcion,this.estatus,this.id), conn);
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

        #region Metodo para eliminar PRoductos
        public int Eliminar_Producto()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("delete from tblProductos where ProductoID={0} ", this.id), conn);
                    retorno = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
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
