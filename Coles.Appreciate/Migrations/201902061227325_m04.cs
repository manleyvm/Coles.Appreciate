namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m04 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AppreciationAgrees", "AppreciationId");
            CreateIndex("dbo.AppreciationAgrees", "ResponseId");
            CreateIndex("dbo.AppreciationReasons", "AppreciationId");
            CreateIndex("dbo.AppreciationReasons", "ReasonId");
            CreateIndex("dbo.Appreciations", "StatusId");
            CreateIndex("dbo.AppreciationTargets", "AppreciationId");
            AddForeignKey("dbo.AppreciationAgrees", "ResponseId", "dbo.Responses", "ResponseId");
            AddForeignKey("dbo.AppreciationReasons", "ReasonId", "dbo.Reasons", "ReasonId", cascadeDelete: true);
            AddForeignKey("dbo.AppreciationAgrees", "AppreciationId", "dbo.Appreciations", "AppreciationId", cascadeDelete: true);
            AddForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations", "AppreciationId", cascadeDelete: true);
            AddForeignKey("dbo.AppreciationTargets", "AppreciationId", "dbo.Appreciations", "AppreciationId", cascadeDelete: true);
            AddForeignKey("dbo.Appreciations", "StatusId", "dbo.Status", "StatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appreciations", "StatusId", "dbo.Status");
            DropForeignKey("dbo.AppreciationTargets", "AppreciationId", "dbo.Appreciations");
            DropForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations");
            DropForeignKey("dbo.AppreciationAgrees", "AppreciationId", "dbo.Appreciations");
            DropForeignKey("dbo.AppreciationReasons", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.AppreciationAgrees", "ResponseId", "dbo.Responses");
            DropIndex("dbo.AppreciationTargets", new[] { "AppreciationId" });
            DropIndex("dbo.Appreciations", new[] { "StatusId" });
            DropIndex("dbo.AppreciationReasons", new[] { "ReasonId" });
            DropIndex("dbo.AppreciationReasons", new[] { "AppreciationId" });
            DropIndex("dbo.AppreciationAgrees", new[] { "ResponseId" });
            DropIndex("dbo.AppreciationAgrees", new[] { "AppreciationId" });
        }
    }
}
