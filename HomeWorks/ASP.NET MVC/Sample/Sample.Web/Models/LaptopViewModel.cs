using Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Sample.Web.Models
{
    public class LaptopViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string ManufacturerName { get; set; }

        public static Expression<Func<Laptop, LaptopViewModel>> FromLaptop
        {
            get
            {
                return l => new LaptopViewModel
                {
                    Id = l.Id,
                    Model = l.Model,
                    ImageUrl = l.ImageUrl,
                    Price = l.Price,
                    ManufacturerName = l.Manufacturer.Name
                };
            }
        }
    }
}