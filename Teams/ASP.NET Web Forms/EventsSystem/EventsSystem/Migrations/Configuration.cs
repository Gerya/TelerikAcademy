namespace EventsSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using EventsSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EventsSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EventsSystem.Models.ApplicationDbContext context)
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
            //context.Database.ExecuteSqlCommand( "ALTER TABLE AspNetUsers ALTER IsDeleted SET DEFAULT 'False'");
            context.Roles.AddOrUpdate( r => r.Name,
                new Role { Name = "Administrator" },
                new Role { Name = "Moderator" },
                new Role { Name = "Registered" }
                );
            context.Status.AddOrUpdate( s => s.InviteStatus,
                new Status{ InviteStatus = "New"},
                new Status{ InviteStatus = "Readed"}
                );
        }
    }
}
