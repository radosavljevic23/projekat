namespace _1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;

    internal sealed class Configuration : DbMigrationsConfiguration<_1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_1.Models.ApplicationDbContext context)
        {
            //create roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(Role.ADMIN))
                roleManager.Create(new IdentityRole(Role.ADMIN));

            if (!roleManager.RoleExists(Role.STUDENT))
                roleManager.Create(new IdentityRole(Role.STUDENT));

            //var pred = new Predmet { Ime = "Informatika", GodinaStudija = 1, Profesor = "Nikola" };
            


            //create administrator
            var adminEmail = WebConfigurationManager.AppSettings["AdministratorEmail"];
            if (!context.Administrators.Any(x => x.Email == adminEmail))
            {
                var password = new ApplicationUserManager(new UserStore<ApplicationUser>(context))
                    .PasswordHasher.HashPassword("password");

                var administrator = new Administrator()
                {
                    Email = adminEmail,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    UserName = adminEmail,
                    PasswordHash = password,
                    Birthdate = DateTime.Now
                };

                context.Administrators.AddOrUpdate(administrator);
                context.SaveChanges();

                var adminManager = new UserManager<Administrator>(new UserStore<Administrator>(context));
                adminManager.AddToRole(administrator.Id, Role.ADMIN);
            }
        }
        ////  This method will be called after migrating to the latest version.

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
        //context.Students.AddOrUpdate(
        //        p => p.brIndexa,
        //        new Models.Student { brIndexa = 12345, Name = "Pera" },
        //        new Models.Student { brIndexa = 22354, Name = "Mika" }
        //    );
        //    context.Administrators.AddOrUpdate(
        //        a => a.korisnickoIme,
        //        new Models.Administrator { korisnickoIme = "nekoneko", Name = "Zika" }
        //        );
        //    context.Predmeti.AddOrUpdate(
        //        p => p.Ime,
        //        new Models.Predmet { Ime = "matematika" }
        //        );
    }
    }


