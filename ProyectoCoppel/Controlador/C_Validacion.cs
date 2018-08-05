using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Controlador
{
    public class C_Validacion
    {
        #region Metodo para validar el usuario
        public void validar_usuario(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch 
            {

            }
        }
        #endregion

        #region Metodo Para Validar La clave
        public void Validar_Clave(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch
            {

            }
        }
        #endregion
    }
}
