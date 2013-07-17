using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Model;
using System.Data.Linq;

namespace Northwind.Model
{
    public partial class Employee
    {
        public EntitySet<Territory> Teritory
        { 
            get
        {
               var teritotyes = new EntitySet<Territory>();
               teritotyes.AddRange(this.Teritory);
                return teritotyes;
        }  
        }
    }
}
