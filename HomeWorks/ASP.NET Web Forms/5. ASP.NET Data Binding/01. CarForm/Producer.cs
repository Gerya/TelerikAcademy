using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.CarForm
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}