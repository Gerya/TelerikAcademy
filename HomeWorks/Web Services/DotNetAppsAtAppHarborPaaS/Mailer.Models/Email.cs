using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Key]
        public string EmailAddress { get; set; }
    }
}
