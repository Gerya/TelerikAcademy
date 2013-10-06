using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sample.Model
{
    public class ApplicationUser: User
    {
        [Required]
        public string Email { get; set; }
    }
}
