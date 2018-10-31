﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektC.BLL
{
    public class Podcast
    {
        public string Url { get; set; }
        public string Kategori { get; set; }
        public string Uppdateringsfrekvens { get; set; }
        public string AntalAvsnitt { get; set; }
        public string Namn { get; set; }
        public List<PodcastAvsnitt> AvsnittLista = new List<PodcastAvsnitt>();
        

    }

}