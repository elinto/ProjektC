using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjektC.DAL
{
    public class KategoriSerializer
    {
        public static void SaveKategorier(List<string> kategoriListan) {
            using (var writer = new StreamWriter("kategorier.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(writer, kategoriListan);
                writer.Flush();
            }
        }

        public static List<string> GetKategorier() {
            if (File.Exists("kategorier.xml") == false)
            {
                return new List<string>();
            }

            using (var stream = File.OpenRead("kategorier.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                return serializer.Deserialize(stream) as List<string>;
            }
        }
    }
}
