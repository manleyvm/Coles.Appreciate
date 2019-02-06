namespace Coles.Appreciate.Migrations
{
    using Coles.Appreciate.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Coles.Appreciate.Models.ColesAppreciateDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Coles.Appreciate.Models.ColesAppreciateDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Appreciation]");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Status]");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Reason]");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Response]");

            if (context.Appreciations.Count() > 0)
                context.Appreciations.RemoveRange(context.Appreciations);
            

            if (context.Responses.Count() > 0)
                context.Responses.RemoveRange(context.Responses);


            if (context.Reasons.Count() > 0)
                context.Reasons.RemoveRange(context.Reasons);

            if (context.Responses.Count() > 0)
                context.Status.RemoveRange(context.Status);


            context.SaveChanges();

            context.Reasons.Add(new Reason() {  ReasonText = "dedication" });
            context.Reasons.Add(new Reason() {  ReasonText = "inspiring" });
            context.Reasons.Add(new Reason() {  ReasonText = "passionate" });
            context.Reasons.Add(new Reason() {  ReasonText = "bold" });

            context.Responses.Add(new Response() { ResponseText = "congrats" });
            context.Responses.Add(new Response() { ResponseText = "welldone" });
            context.Responses.Add(new Response() { ResponseText = "impressive" });
            context.Responses.Add(new Response() { ResponseText = "wow" });

            context.Status.Add(new Status() { StatusText = "Edit", StatusCode = 0 });
            context.Status.Add(new Status() { StatusText = "Confirmed", StatusCode = 10 });
            context.Status.Add(new Status() { StatusText = "Deleted" , StatusCode = 99 });

            context.SaveChanges();

            Status editStatus =context.Status.Where(x => x.StatusCode == 0).Single();
            Console.Write(editStatus.StatusId);
            
            context.Appreciations.Add(new Appreciation() { AppreciationText = "GoodWork!", StatusId = editStatus.StatusId });
            context.Appreciations.Add(new Appreciation() { AppreciationText = "Unblieveable!", StatusId = editStatus.StatusId });
            context.Appreciations.Add(new Appreciation() { AppreciationText = "Credit to you!", StatusId = editStatus.StatusId });

            context.SaveChanges();

            Appreciation firstAppreciation = context.Appreciations.First();
            Response firstResponse = context.Responses.First();
            Reason firstReason = context.Reasons.First();

            context.AppreciationAgrees.Add(new AppreciationAgree() { AppreciationId = firstAppreciation.AppreciationId, ResponseId = firstResponse.ResponseId, UserId = "jsmith" });
            context.AppreciationAgrees.Add(new AppreciationAgree() { AppreciationId = firstAppreciation.AppreciationId, ResponseId = firstResponse.ResponseId, UserId = "mbaker" });
            context.AppreciationAgrees.Add(new AppreciationAgree() { AppreciationId = firstAppreciation.AppreciationId, ResponseId = firstResponse.ResponseId, UserId = "ydocker" });

            context.AppreciationReasons.Add(new AppreciationReason() { AppreciationId = firstAppreciation.AppreciationId, ReasonId = firstReason.ReasonId });
            context.AppreciationReasons.Add(new AppreciationReason() { AppreciationId = firstAppreciation.AppreciationId, ReasonId = firstReason.ReasonId });
            context.AppreciationReasons.Add(new AppreciationReason() { AppreciationId = firstAppreciation.AppreciationId, ReasonId = firstReason.ReasonId });

            context.SaveChanges();








        }
    }
}
