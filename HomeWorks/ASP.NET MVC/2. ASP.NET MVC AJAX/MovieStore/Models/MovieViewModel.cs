using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Models
{
    public class MovieViewModel
    {
        private const int CurrentYear = 2013;

        public MovieViewModel()
        {
            this.Actresses = new List<SelectListItem>();
            this.Actors = new List<SelectListItem>();
            this.Directors = new List<SelectListItem>();
            this.Studios = new List<SelectListItem>();
        }
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        //[Range(1900, CurrentYear)]
        public Nullable<int> Year { get; set; }

        //[RegularExpression(@"^[a-zA-Z -]{5,150}$", ErrorMessage = "The name can contain only letter and -, and must be between 5 and 150 letters")]
        public string LeadingActorName { get; set; }

        //[RegularExpression(@"^[a-zA-Z -]{5,150}$", ErrorMessage = "The name can contain only letter and -, and must be between 5 and 150 letters")]
        public string LeadingActressName { get; set; }

        //[Required, RegularExpression(@"^[a-zA-Z -]{5,150}$", ErrorMessage = "The name can contain only letter and -, and must be between 5 and 150 letters")]
        public string DirectorName { get; set; }

        //[Required, RegularExpression(@"^[a-zA-Z -]{5,150}$", ErrorMessage = "The name can contain only letter and -, and must be between 5 and 150 letters")]
        public string StudioName { get; set; }


        public IEnumerable<SelectListItem> Actors { get; set; }

        public IEnumerable<SelectListItem> Actresses { get; set; }

        public IEnumerable<SelectListItem> Directors { get; set; }

        public IEnumerable<SelectListItem> Studios { get; set; }

        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return movie => new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    DirectorName = movie.Director.Name,
                    LeadingActorName = movie.Actor.Name,
                    LeadingActressName = movie.Actress.Name,
                    StudioName = movie.Studio.Name
                };
            }
        }
    }
}