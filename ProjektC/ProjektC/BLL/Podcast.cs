using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProjektC.BLL
{
    public class Podcast : ITitle
    {
        public string Url { get; set; }
        public string Kategori { get; set; }
        public string Uppdateringsfrekvens { get; set; }
        public string AntalAvsnitt { get; set; }
        public string Titel { get; set; }
        public List<PodcastAvsnitt> AvsnittLista = new List<PodcastAvsnitt>();

        [XmlIgnore]
        public Timer uppdateringsTimer = new Timer();
    }
}