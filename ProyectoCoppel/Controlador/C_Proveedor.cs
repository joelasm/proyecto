using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using System.Data;
namespace Controlador
{
    public class C_Proveedor
    {
        M_Proveedor M_prov = new M_Proveedor();
        int retorno;

        #region Metodo enviar Proveedor 
        public int Ins_proveedor(string rfc, string nombre, string estado)
        {
                M_prov.rfc = rfc;
                M_prov.nombre = nombre;
                M_prov.estatus = estado;
                retorno = M_prov.insertar();
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

        #region Metodo para actualizar proveedor
        public void Act_Proveedor(int id,string rfc, string nom, string estado)
        {
            M_prov.id = id;
            M_prov.rfc = rfc;
            M_prov.nombre = nom;
            M_prov.estatus = estado;
            retorno = M_prov.Actualizar_proveedor();
            if (retorno > 0)
            {
                MessageBox.Show("Se Actualizo con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error al actualizar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region metodo para mendar los proveedores
        public DataTable llenar_dgv()
        {
            DataTable dt = M_prov.mostra_Proveedor();

            return dt;
        }
        #endregion

        #region Metodo para llenar combobox
        public DataTable cmb_proveedores()
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

        #region Metodo para ELiminar un Proveedor
        public void Elm_Proveedor(int id)
        {
            M_prov.id = id;
            retorno = M_prov.Eliminar_Proveedor();
            if (retorno > 0)
            {
                MessageBox.Show("EL Proveedor Fue eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el proveedor, tiene productos agrgados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

    }
}
