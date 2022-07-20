using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Episode
    {
        
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Link { get; set; }

        public static List<Episode> extent = new List<Episode>();

        public Episode(int Number)
        {
            this.Number = Number;
            addExtent(this);
        }

        private static void addExtent(Episode episode)
        {
            extent.Add(episode);
        }
        private static void removeExtent(Episode episode)
        {
            extent.Remove(episode);
        }
               
    }
}
