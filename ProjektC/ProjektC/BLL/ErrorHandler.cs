using System;
using System.Windows.Forms;

namespace ProjektC.BLL
{
    public class ErrorHandler
    {
        public static void HanteraFel(Exception ex) {
            MessageBox.Show(ex.Message, "Något gick fel!", MessageBoxButtons.OK);
        }
    }
}
