namespace ProjektC.BLL.Validering
{
    public class TextValiderare
    {
        public virtual void ValideraInput(string input)
        {
            if(input.Length <= 2)
            {
                throw new ValideringsException("Ange mer än 2 tecken");
            }
        }
    }
}
