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
    public class clsConexion
    {
        public static SqlConnection conectar()
        {
            SqlConnection conexion = null;
            try
            {

                conexion = new SqlConnection(("Data source=DESKTOP-KMMTJEB\\SQLEXPRESS01; Initial Catalog=bdProyecto; Integrated Security=true"));
                conexion.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje", "Error en la conexion: " + ex.ToString());
            }
            return conexion;
        }
    }
}
