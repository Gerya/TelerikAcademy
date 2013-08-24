using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailer.Data.Migrations;
using Mailer.Models;

namespace Mailer.Data
{
    public class MailerContext : DbContext
    {
        static MailerContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailerContext, Configuration>());
        }

        public MailerContext()
            : base("Name=MailerConnection")
        {

        }

        public DbSet<Email> Emails { get; set; }
    }
}
