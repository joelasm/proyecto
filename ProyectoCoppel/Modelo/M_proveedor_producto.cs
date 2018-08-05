using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Modelo
{
   public  class M_proveedor_producto : clsVariables
    {
        SqlDataAdapter da = null;
        int retorno;

        #region metodo para seleccionar los productos que no han sido agregados 
        public DataTable mostrar_productos()
        {
            DataSet dsproductos = new DataSet();
            using (SqlConnection conn = clsConexion.conectar())
            {
                da = new SqlDataAdapter("Select ProductoId, Descripcion From tblProductos where Not ProductoID In (Select ProductoID From tblProveedorProducto) and Estatus='true'", conn);
                da.Fill(dsproductos, "productos");
                conn.Close();
                conn.Dispose();
                return dsproductos.Tables[0];
            }

        }

        #endregion

        #region metodo para seleccionar todos los proveedores Activos
        public DataTable mostra_Proveedoractivo()
        {
            DataSet dsproveedor = new DataSet();
            using (SqlConnection conn = clsConexion.conectar())
            {
                da = new SqlDataAdapter("select ProveedorId,nombre from tblProveedores where Estatus='True'", conn);
                da.Fill(dsproveedor, "proveedor");
                conn.Close();
                conn.Dispose();
                return dsproveedor.Tables[0];
            }

        }

        #endregion

        #region metodo para seleccionar todo de la tabla proveedores-productos
        public DataTable mostra_prov_prod()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = clsConexion.conectar())
            {
                da = new SqlDataAdapter("select  Prov_prod.ProveedorId as [IdProv],prov.nombre as[Proveedor],Prov_prod.ProductoId as[IdProd] ,prod.Descripcion as[Producto]  from tblProveedorProducto Prov_prod inner join tblProveedores prov on Prov_prod.ProveedorId=prov.ProveedorId  inner join tblProductos prod on Prov_prod.ProductoId=prod.ProductoID", conn);
                da.Fill(ds, "proveedor");
                conn.Close();
                conn.Dispose();
                return ds.Tables[0];
            }

        }

        #endregion

        #region Metodo para insertar Registro
        public int insertar_prov_prod()
        {

            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("insert into tblProveedorProducto (ProveedorId,ProductoId) values ({0},{1})", this.id_prov,this.id_prod), conn);
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

        #region Metodo para Eliminar registros
        public int Eliminar_registro()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                SqlCommand comando = new SqlCommand(string.Format("delete from tblProveedorProducto where ProveedorId={0} and ProductoId= {1}", this.id_prov,this.id_prod), conn);
                retorno = comando.ExecuteNonQuery();
                conn.Dispose();
                conn.Close();
            }
            return retorno;
        }
        #endregion

        #region Metodo para actualizar registros
        public int Actualizar_registros()
        {
            using (SqlConnection conn = clsConexion.conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(String.Format("update tblProveedorProducto set ProveedorId={0}, ProductoId={1} where  ProductoId={2}", this.id_prov,this.id_prod,this.id), conn);
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

    }
}
