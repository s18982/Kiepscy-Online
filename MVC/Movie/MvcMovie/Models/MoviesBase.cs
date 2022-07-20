using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MvcMovie.Models
{
    public class MoviesBase
    {
        public List<Episode> Episodes { get; set; }

        public MoviesBase()
        {
            Episodes = new List<Episode>();
        }

        public void ReadAllEpisodesToBase()
        {
            string[] lines = System.IO.File.ReadAllLines(@"../MvcMovie/Data/links.txt");
            string[] linesWiki = System.IO.File.ReadAllLines(@"../MvcMovie/Data/All_Info.csv");

            int x = linesWiki.Length;
            int[] tab = new int[x];
            
            for (int i = 0; i < x; i++)
            {
                int counter = 3;
                string num="", title="", desc="", date="";

                tab[i] = int.Parse(Regex.Match(linesWiki[i], @"\d+").Value);

                char[] arr = linesWiki[i].ToCharArray();
                for(int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] != ';')
                    {
                        if(counter == 3)
                        {
                            num += arr[j];
                        }
                        if (counter == 2)
                        {
                            title += arr[j];
                        }
                        if (counter == 1)
                        {
                            desc += arr[j];
                        }
                        if (counter == 0)
                        {
                            date += arr[j];
                        }
                    }
                    else
                        counter--;
                }
                int number = int.Parse(num);
                int year = int.Parse(date.Substring(6,4));

                Episode episode = new Episode(number);
                episode.Title = title;
                episode.Description = desc;
                episode.Year = year;

                Episodes.Add(episode);
            }

            for(int i = 0; i < lines.Length; i++)
            {
                int odc = int.Parse(Regex.Match(lines[i], @"\d+").Value);
                string url = Regex.Match(lines[i], @"\b(?:http?://|www\.)\S+\b").Value;
                Episodes.ElementAt(odc - 1).Link = url;
            }
            foreach(Episode ep in Episodes)
            {
                if(ep.Link == null)
                {
                    ep.Link = "Brak linku";
                }
            }
            
        }
    }
}
