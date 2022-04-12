using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
                _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }



        [Route("movie/filter/{id}")]
        public ActionResult GetMovieById(int id)
        {
            Movie movie = _context.Movies.Include(c => c.Genre).Where(x => x.Id == id).SingleOrDefault();
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Include(c => c.Genre).Where(x => x.Id == id).SingleOrDefault();
            if (movie == null)
                movie = new Movie();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m=>m.Id == movie.Id);
                movieInDb.Title = movie.Title;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.AddedDate = movie.AddedDate;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            return View("Index", _context.Movies.Include(m => m.Genre).ToList());
        }
    }
}