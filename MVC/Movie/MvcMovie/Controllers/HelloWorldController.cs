using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
       
        // .../HelloWorld
        public IActionResult Index()
        {
            
            return View();
        }

        // .../HelloWorld/Character/{id}?name={name}
        public IActionResult Character(string name, int id)
        {
            ViewData["Message"] = "Twoja postac to " + name + ", jej ilosc to " + id + ".";

            return View();
        }

    }
}
