using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Controlador
{
    public class C_usuario
    {
        int retorno;
        M_Usuario M_usua = new M_Usuario();

        #region Metodo para enviar usuario
        public int Ins_usuario(string Clave, string r_clave,string Nom,string apellido,string fecha_nac,string estado)
        {
            if (Clave == r_clave)
            {
                M_usua.Clave = Clave;
                M_usua.nombre = Nom;
                M_usua.apellido = apellido;
                M_usua.fecha = fecha_nac;
                M_usua.estatus = estado;
                retorno = M_usua.insertar_Usuario();
                if (retorno > 0)
                {
                    MessageBox.Show("Se guardo con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error al guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                MessageBox.Show("La contraseña no coincide", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }
        #endregion

        #region Metodo para llenar combobox
        public DataTable cmb_Usuario()
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

        #region Metodo para seleccionar el id
        public string sel_id()
        {
            string id;
            id = M_usua.Sel_idusiario();
            return id;
        }
        #endregion

        #region Metodo para seleccionar un usuario
        public DataTable dt_usuario(int id, string clave)
        {
            M_usua.id = id;
            M_usua.Clave = clave;
            DataTable dt_usu = M_usua.Sel_usuario();
            return dt_usu;
        }
        #endregion

        #region Metodo para Actualizar la clave
        public int Act_Clave(int id, string clave, string Nclave)
        {
            M_usua.id = id;
            M_usua.Clave = clave;
            M_usua.NClave = Nclave;
            retorno = M_usua.Act_Clave();
            if (retorno > 0)
            {
                MessageBox.Show("Se Actualizo la clave", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("No se pudo Actualizar la clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }
        #endregion

        #region Metodo para actualizar datos
        public void Act_Datos(int id, string clave, string nombre, string apellido, string fecha, string estado)
        {
            M_usua.id = id;
            M_usua.Clave = clave;
            M_usua.nombre = nombre;
            M_usua.apellido = apellido;
            M_usua.fecha = fecha;
            M_usua.estatus = estado;
            retorno = M_usua.Act_Datos();
            if (retorno > 0)
            {
                MessageBox.Show("Se Actualizo la contraseña", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("No se pudo Actualizar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Metodo para eliminar usuario
        public int Elim_usuario(int id,string clave)
        {
            M_usua.id = id;
            M_usua.Clave = clave;
            retorno = M_usua.Elim_usuario();
            if (retorno == 1)
            {
                MessageBox.Show("EL usuraio Fue eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (retorno == 0)
            {
                MessageBox.Show("No se pudo eliminar el usuario, verifique el usuario y/o clave", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el usuario, Primero elimine los comentarios", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }
        #endregion

        #region metodo de busqueda de usuario para login
        public int buscar_usuario(int id, string clave, int opc)
        {
            M_usua.id = id;
            M_usua.Clave = clave;
            M_usua.opc_busqueda = opc;
            retorno = M_usua.Buscar_usuario();
         
            return retorno;
        }
        #endregion
        

    }
}
