namespace ProjektC.BLL.Validering
{
    public class ComboboxValiderare : TextValiderare
    {
        public override void ValideraInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ValideringsException("Ange ett värde i comboboxen");
            }
        }
    }
}
