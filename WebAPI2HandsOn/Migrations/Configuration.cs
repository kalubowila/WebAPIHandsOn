namespace WebAPI2HandsOn.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI2HandsOnContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPI2HandsOnContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Contacts.AddOrUpdate(new Contact[] {
              new Contact { FirstName = "Andrew", LastName = "Peters" },
              new Contact { FirstName = "Brice" , LastName = "Lambson" },
              new Contact { FirstName = "Rowan" , LastName = "Miller" }
            });

        }
    }
}
