using ProjektC.BLL.Validering;
using System;
using System.Windows.Forms;

namespace ProjektC.BLL
{
    public class ErrorHandler
    {
        public static void HanteraFel(Exception ex)
        {
            if (ex.GetType() == typeof(ValideringsException))
            {
                MessageBox.Show(ex.Message, "Valideringsfel", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(ex.Message, "Något gick fel!", MessageBoxButtons.OK);
            }
        }
    }
}
