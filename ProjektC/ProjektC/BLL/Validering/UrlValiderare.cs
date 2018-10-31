using System;

namespace ProjektC.BLL.Validering
{
    public class UrlValiderare : TextValiderare
    {
        public override void ValideraInput(string input)
        {
            if (Uri.IsWellFormedUriString(input, UriKind.Absolute) == false)
            {
                throw new ValideringsException("Ange en giltig url");
            }
        }
    }
}
