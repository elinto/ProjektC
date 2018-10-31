using System;

namespace ProjektC.BLL
{
    public class PodcastException : Exception
    {
        public PodcastException()
        {
        }

        public PodcastException(string message)
            : base(message)
        {
        }

        public PodcastException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
