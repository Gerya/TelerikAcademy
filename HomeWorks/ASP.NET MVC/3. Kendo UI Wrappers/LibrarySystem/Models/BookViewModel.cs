using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(30)]
        public string ISBN { get; set; }

        [MaxLength(300)]
        public string WebSite { get; set; }

        [Required]
        public CategoryViewModel Category { get; set; }

        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    WebSite = b.WebSite,
                    Category = new CategoryViewModel
                    {
                        Id = b.CategoryId,
                        Name = b.Category.Name
                    }
                };
            }
        }
    }
}