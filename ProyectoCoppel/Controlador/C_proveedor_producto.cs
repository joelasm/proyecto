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
    public class C_proveedor_producto
    {
        M_proveedor_producto M_prov_prod = new M_proveedor_producto();
        DataTable dt = null;
        int retorno;

        #region metodo paramostrar los productos no agregados a proveedores
        public DataTable MostrarProductos()
        {
            dt = M_prov_prod.mostrar_productos();
            return dt;
        }
        #endregion

        #region metodo para mostrar los proveedores
        public DataTable Mostrar_proveedoractivo()
        {
            dt = M_prov_prod.mostra_Proveedoractivo();

            return dt;
        }
        #endregion

        #region metodo para mostrar los proveedore y productos
        public DataTable Mostrar_prov_prod()
        {
            dt = M_prov_prod.mostra_prov_prod();

            return dt;
        }
        #endregion

        #region Metodo para Insertar proveedor_Producto
        public int Ins_prov_prod(int idprov, int idprod)
        {
            M_prov_prod.id_prov = idprov;
            M_prov_prod.id_prod = idprod;
            retorno = M_prov_prod.insertar_prov_prod();

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

        #region Metodo para eliminar un registro
        public void Eliminar_Registro(int idprov, int idprod)
        {
            M_prov_prod.id_prov = idprov;
            M_prov_prod.id_prod = idprod;
            retorno = M_prov_prod.Eliminar_registro();
            if (retorno > 0)
            {
                MessageBox.Show("Se elimino el registro","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Metodo para Actulizar Registro
        public int Act_registro(int idprov, int idprod, int id)
        {
            M_prov_prod.id_prov = idprov;
            M_prov_prod.id_prod = idprod;
            M_prov_prod.id = id;
            retorno = M_prov_prod.Actualizar_registros();

            if (retorno > 0)
            {
                MessageBox.Show("El registro se Actualizo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo Actualizar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return retorno;
        }
        #endregion
    }
}
