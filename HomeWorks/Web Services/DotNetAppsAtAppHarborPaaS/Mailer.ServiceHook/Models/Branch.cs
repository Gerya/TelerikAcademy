using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mailer.ServiceHook.Models
{
    public class Branch
    {
        public string Name { get; set; }
        public Commit Commit { get; set; }
    }
}