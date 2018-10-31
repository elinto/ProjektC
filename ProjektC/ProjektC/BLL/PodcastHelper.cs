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

        public static int GetUppdateringsfrekvensMilliseconds(string Uppdateringsfrekvens)
        {
            if (Uppdateringsfrekvens == "Var 10:e minut")
            {
                return 600000;
            }
            if (Uppdateringsfrekvens == "Var 20:e minut")
            {
                return 1200000;
            }
            if (Uppdateringsfrekvens == "Var 30:e minut")
            {
                return 1800000;
            }

            throw new System.Exception("Hittade inte uppdateringsfrekvensen");
        }
    }
}
