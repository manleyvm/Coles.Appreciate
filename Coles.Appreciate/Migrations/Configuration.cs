namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Coles.Appreciate.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Coles.Appreciate.Models.ColesAppreciateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Coles.Appreciate.Models.ColesAppreciateContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand("truncate table ReasonTypes");
            context.Database.ExecuteSqlCommand("truncate table ResponseTypes");

            context.ReasonTypes.AddOrUpdate(x => x.ReasonId,
                new ReasonType() { ReasonId = 0, ReasonText = "passionate" },
                new ReasonType() { ReasonId = 0, ReasonText = "fun" },
                new ReasonType() { ReasonId = 0, ReasonText = "nobel" },
                new ReasonType() { ReasonId = 0, ReasonText = "amazing" }
                );

            context.ResponseTypes.AddOrUpdate(x => x.ResponseId,
                new ResponseType() { ResponseId = 0, ResponseText = "rpassionate" },
                new ResponseType() { ResponseId = 0, ResponseText = "rfun" },
                new ResponseType() { ResponseId = 0, ResponseText = "rnobel" },
                new ResponseType() { ResponseId = 0, ResponseText = "ramazing" }
                );
        }
    }
}
