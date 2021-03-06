﻿using Rently.Models;
using Rently.ViewModel;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Rently.ViewModels;

namespace Rently.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreTypes = _context.Genres.ToList();
            var movie = new Movie();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genreTypes
            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies
                        .Include(m => m.Genre)
                        .SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }

        // movies
        public ActionResult Index()
        {
            try
            {
                if (User.IsInRole(RoleName.CanManageMovies))
                    return View("List");

                return View("ReadOnlyList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDB.Name = movie.Name;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
           

            return RedirectToAction("Index", "Movies");
        }
    }
}