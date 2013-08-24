using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mailer.ServiceHook.Models
{
    public class AppHarborStatus
    {
        public Application Application { get; set; }
        public Build Build { get; set; }
    }
}