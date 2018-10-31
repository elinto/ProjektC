using System;

namespace ProjektC.BLL.Validering
{
    public class ValideringsException : Exception
    {
        public ValideringsException(string message) : base(message)
        {
        }
    }
}
