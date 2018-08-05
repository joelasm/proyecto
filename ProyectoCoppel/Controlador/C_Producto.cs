using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Modelo;
namespace Controlador
{
    public class C_Producto
    {
        M_Producto M_prod = new M_Producto();
        DataTable dt = null;
        int retorno;
        #region Metodo insertar producto
        public int Ins_proveedor(string Desc, string estado)
        {
            M_prod.descripcion = Desc;
            M_prod.estatus = estado;
            retorno = M_prod.insertar_Producto();
            if (retorno > 0)
            {
                MessageBox.Show("Se guardo con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error al guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }
        #endregion

        #region Metodo para actualizar un Producto
        public int Act_Producto(string Desc,string estado, int id)
        {
            M_prod.descripcion = Desc;
            M_prod.estatus = estado;
            M_prod.id = id;
            retorno = M_prod.Actualizar_producto();
            if (retorno > 0)
            {
                MessageBox.Show("Se actualizo con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("El producto no puede cambiar el Estatus", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }
        #endregion

        #region metodo para mandar todos los productos
        public DataTable llenar_dgv()
        {
            dt = M_prod.mostra_Productos();
            return dt;
        }
        #endregion
        
        #region Metodo para llenar combobox
        public DataTable cmb_Estatus()
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

        #region Metodo para ELiminar un Producto
        public void Elm_Producto(int id)
        {
            M_prod.id = id;
            retorno = M_prod.Eliminar_Producto();
            if (retorno > 0)
            {
                MessageBox.Show("EL Producto Fue eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el producto, se ha agregado a un proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
    }
}
