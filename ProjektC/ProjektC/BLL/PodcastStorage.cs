using ProjektC.DAL;
using System.Collections.Generic;

namespace ProjektC.BLL
{
    public class PodcastStorage
    {
        public static void SavePodcasts(List<Podcast> podcastListan)
        {
            PodcastSerializer.SavePodcasts(podcastListan);
        }

        public static List<Podcast> GetPodcasts()
        {
            return PodcastSerializer.GetPodcasts();
        }
    }
}
