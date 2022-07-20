using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MvcMovie.Controllers
{
    public class EpisodesController : Controller
    {
        public IActionResult Episode(int id)
        {
            if(id<1 || id > 576)
            {
                return View("~/Views/Episodes/ErrorEpisode.cshtml");
            }

            MoviesBase moviesBase = new MoviesBase();
            moviesBase.ReadAllEpisodesToBase();
            List<Episode> episodes = moviesBase.Episodes;

            ViewData["Num"] = episodes.ElementAt(id - 1).Number;
            ViewData["Ep_Tit"] = episodes.ElementAt(id - 1).Title;
            ViewData["Desc"] = episodes.ElementAt(id - 1).Description;
            ViewData["Year"] = episodes.ElementAt(id - 1).Year;
            ViewData["Link"] = episodes.ElementAt(id-1).Link;
            return View();
        }


        
      

        public IActionResult Index()
        {
            MoviesBase moviesBase = new MoviesBase();
            moviesBase.ReadAllEpisodesToBase();
            List<Episode> episodes = moviesBase.Episodes;

            string str = "Data";
            int counter = 1;

            foreach (Episode ep in episodes)
            {
                ViewData[str + counter + "_num"] = ep.Number; 
                ViewData[str + counter + "_title"] = ep.Title;
                ViewData[str + counter + "_desc"] = ep.Description;
                ViewData[str + counter + "_year"] = ep.Year;
                ViewData[str + counter + "_link"] = ep.Link;

                ViewData[str + counter + "_end"] = "../Episodes/Episode/" + counter;

                counter++;
            }
            

            return View();
        }
    }
}
