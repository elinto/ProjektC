using ProjektC.DAL;
using System.Collections.Generic;
namespace ProjektC.BLL
{
    public class KategoriStorage
    {
        public static void SaveKategorier(List<string> kategoriListan)
        {
            KategoriSerializer.SaveKategorier(kategoriListan);
        }

        public static List<string> GetKategorier()
        {
            return KategoriSerializer.GetKategorier();
        }
    }
}
