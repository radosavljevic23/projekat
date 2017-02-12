namespace _1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_1.Models.ApplicationDbContext context)
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
            context.Students.AddOrUpdate(
                p => p.brIndexa,
                new Models.Student { brIndexa = 12345, Name ="Pera" },
                new Models.Student { brIndexa = 22354, Name = "Mika" }
            );
            context.Administrators.AddOrUpdate(
                a => a.username,
                new Models.Administrator { username = "nekoneko", Name = "Zika" }
                );
            context.Predmeti.AddOrUpdate(
                p=>p.Ime,
                new Models.Predmet { Ime = "matematika" }
                );
        }
    }
}
