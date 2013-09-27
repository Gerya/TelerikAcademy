using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDbEntities context;

        public MoviesController()
        {
            this.context = new MoviesDbEntities();
        }

        //
        // GET: /Movies/
        public ActionResult Index()
        {
            var movies = this.context.Movies.
                Include(m => m.Actor)
                .Include(m => m.Actress)
                .Include(m => m.Director)
                .Include(m => m.Studio)
                .Select(MovieViewModel.FromMovie);
            return View(movies);
        }

        [HttpPost]
        public ActionResult Update(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                if (movie != null)
                {
                    var movieToUpdate = context.Movies.Find(movie.Id);

                    if (movieToUpdate != null)
                    {
                        var actorId = Convert.ToInt32(movie.LeadingActorName);
                        if (actorId != 1)
                        {
                            movieToUpdate.Actor = context.Actors.Find(actorId);
                        }

                        var actressId = Convert.ToInt32(movie.LeadingActressName);
                        if (actressId != 1)
                        {
                            movieToUpdate.Actress = context.Actresses.Find(actressId);
                        }

                        var directorId = Convert.ToInt32(movie.DirectorName);
                        movieToUpdate.Director = context.Directors.Find(directorId);

                        var studioId = Convert.ToInt32(movie.StudioName);
                        movieToUpdate.Studio = context.Studios.Find(studioId);

                        if (movieToUpdate.Title != movie.Title)
                        {
                            movieToUpdate.Title = movie.Title;
                        }

                        if (movieToUpdate.Year != movie.Year)
                        {
                            movieToUpdate.Year = movie.Year;
                        }

                        context.SaveChanges();
                        return Content("");
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Movie with id={0} doesn't exist.", movie.Id));
                    }
                }
                else
                {
                    throw new ArgumentNullException("movie");
                }
            }

            return PartialView("_Edit", movie);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MovieViewModel movie)
        {
            CreateDropDownData(movie);

            return PartialView("_Edit", movie);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(MovieViewModel movie)
        {
            var movieToDelete = context.Movies.Find(movie.Id);
            if (movieToDelete != null)
            {
                context.Movies.Remove(movieToDelete);
                context.SaveChanges();
                return Content("");
            }
            else
            {
                throw new ArgumentException("No movie specified.");
            }
        }

        [HttpPost]
        public ActionResult Delete(MovieViewModel movie)
        {
            return PartialView("_Delete", movie);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var movie = new MovieViewModel();
            CreateDropDownData(movie);

            return PartialView("_Create", movie);
        }

        [HttpPost]
        public ActionResult Create(MovieViewModel movie)
        {
            if (movie != null)
            {
                var newMovie = new Movie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                };

                var actorId = Convert.ToInt32(movie.LeadingActorName);
                if (actorId != 1)
                {
                    newMovie.Actor = context.Actors.Find(actorId);
                }

                var actressId = Convert.ToInt32(movie.LeadingActressName);
                if (actressId != 1)
                {
                    newMovie.Actor = context.Actors.Find(actressId);
                }

                var directorId = Convert.ToInt32(movie.DirectorName);
                newMovie.Director = context.Directors.Find(directorId);

                var studioId = Convert.ToInt32(movie.StudioName);
                newMovie.Studio = context.Studios.Find(studioId);

                context.Movies.Add(newMovie);
                context.SaveChanges();
            }

            return Content("");
        }

        private void CreateDropDownData(MovieViewModel movie)
        {
            movie.Actresses = context.Actresses.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            movie.Actors = context.Actors.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            movie.Studios = context.Studios.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            movie.Directors = context.Directors.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
}