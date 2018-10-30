using ProjektC.BLL;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProjektC.DAL
{
    public class PodcastSerializer
    {
        public static void SavePodcasts(List<Podcast> podcastListan)
        {
            using (var writer = new StreamWriter("podcasts.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Podcast>));
                serializer.Serialize(writer, podcastListan);
                writer.Flush();
            }
        }

        public static List<Podcast> GetPodcasts()
        {
            if (File.Exists("podcasts.xml") == false) {
                return new List<Podcast>();
            }

            using (var stream = File.OpenRead("podcasts.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Podcast>));
                return serializer.Deserialize(stream) as List<Podcast>;
            }
        }
    }
}
