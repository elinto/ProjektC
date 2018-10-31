using System.Xml;

namespace ProjektC.BLL
{
    public class PodcastHelper
    {
        public static void SetAvsnitt(Podcast p, XmlNodeList avsnittLista) {
            p.AvsnittLista.Clear();

            foreach (XmlNode xmlAvsnitt in avsnittLista)
            {
                var avsnitt = new PodcastAvsnitt();
                avsnitt.Titel = xmlAvsnitt.SelectSingleNode("title").InnerText;
                avsnitt.Beskrivning = xmlAvsnitt.SelectSingleNode("description").InnerText;
                p.AvsnittLista.Add(avsnitt);
            }
        }
    }
}
