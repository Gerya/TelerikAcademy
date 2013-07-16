using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Model;

namespace Inherit
{
    public class EmployeeExtd : Employee
    {
        public IEnumerable<Region> Teritory { get;}
    }
}
