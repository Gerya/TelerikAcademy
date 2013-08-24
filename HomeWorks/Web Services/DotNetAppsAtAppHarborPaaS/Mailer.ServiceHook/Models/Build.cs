using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mailer.ServiceHook.Models
{
    public class Build
    {
        public string Id { get; set; }
        public Branch Branch { get; set; }
        public string Status { get; set; }
        public string Url { get; set; }
    }
}