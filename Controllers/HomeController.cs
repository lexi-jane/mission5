using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movie_collection.Models;
using Microsoft.EntityFrameworkCore;

namespace movie_collection.Controllers
{
    public class HomeController : Controller
    {
        private MovieData MovieContext { get; set; }

        //Constructor
        public HomeController(MovieData randoName)
        {
            MovieContext = randoName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }


        ////////// CREATE //////////
        [HttpGet]
        public IActionResult MovieEntry()
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieEntry(MovieAdd movie)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(movie);
                MovieContext.SaveChanges();
                return View("Complete", movie);
            }
            else //if invalid
            {
                ViewBag.Categories = MovieContext.Categories.ToList();

                return View(movie);
            }
        }


        ////////// READ LIST //////////
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = MovieContext.MovieAdds
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }


        ////////// EDIT  //////////
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var mv = MovieContext.MovieAdds.Single(x => x.MovieID == movieid);

            return View("MovieEntry", mv);
        }


        ////////// UPDATE  //////////
        [HttpPost]
        public IActionResult Edit(MovieAdd ma)
        {
            MovieContext.Update(ma);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        ////////// DELETE //////////
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var mv = MovieContext.MovieAdds.Single(x => x.MovieID == movieid);
            return View(mv);
        }
        [HttpPost]
        public IActionResult Delete(MovieAdd ma)
        {
            MovieContext.MovieAdds.Remove(ma);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
