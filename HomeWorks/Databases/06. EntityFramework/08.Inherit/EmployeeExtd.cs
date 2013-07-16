using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Model;
using System.Data.Linq;

namespace Inherit
{
    public class EmployeeExtd : Employee
    {
        public EntitySet<Territory> Teritory { get; set; }
    }
}
