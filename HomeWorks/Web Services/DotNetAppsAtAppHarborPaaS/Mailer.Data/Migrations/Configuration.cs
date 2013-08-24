namespace Mailer.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Mailer.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Mailer.Data.MailerContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Mailer.Data.MailerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Emails.AddOrUpdate(
                e => e.EmailAddress,
                new Email()
                {
                    EmailAddress = "a@a.com"
                },
                new Email()
                {
                    EmailAddress = "b@a.com"
                },
                new Email()
                {
                    EmailAddress = "c@a.com"
                },
                new Email()
                {
                    EmailAddress = "d@a.com"
                });
        }
    }
}
