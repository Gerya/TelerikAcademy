using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }

        //public Expression<Func<Category, CategoryViewModel>> FromCategory
        //{
        //    get
        //    {
        //        return b => new CategoryViewModel
        //        {
        //            Id = b.Id,
        //            Name = b.Name,
        //        };
        //    }
        //}
    }
}