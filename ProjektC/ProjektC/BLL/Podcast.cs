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



        //public Podcast(string upp) {

        // upp = Uppdateringsfrekvens; }

        // public string Upddateringsfrekvens() {

        // {
        //    return "hej";
        // }
        // } }



    }
    public class Exceptions : Exception
    {
        public Exceptions()
        {
        }

        public Exceptions(string message)
            : base(message)
        {
        }

        public Exceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}