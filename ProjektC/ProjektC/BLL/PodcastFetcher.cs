using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace ProjektC.BLL
{
    public class PodcastFetcher
    {
        public static async Task<XmlDocument> FetchPodcastAsync(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var document = new XmlDocument();
                    document.Load(stream);
                    return document;
                }
            }
        }
    }
}
