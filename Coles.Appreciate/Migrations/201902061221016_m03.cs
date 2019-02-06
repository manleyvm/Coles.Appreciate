namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppreciationAgrees", "AppreciationId", "dbo.Appreciations");
            DropForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations");
            DropIndex("dbo.AppreciationAgrees", new[] { "AppreciationId" });
            DropIndex("dbo.AppreciationReasons", new[] { "AppreciationId" });
            CreateTable(
                "dbo.AppreciationTargets",
                c => new
                    {
                        AppreciationTargetId = c.Int(nullable: false, identity: true),
                        AppreciationId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.AppreciationTargetId);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonId = c.Int(nullable: false, identity: true),
                        ReasonText = c.String(),
                        create_date_time = c.DateTime(),
                        mod_date_time = c.DateTime(),
                        user_id = c.String(),
                    })
                .PrimaryKey(t => t.ReasonId);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        ResponseText = c.String(),
                    })
                .PrimaryKey(t => t.ResponseId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusText = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("dbo.Appreciations", "SourceUserId", c => c.String());
            AddColumn("dbo.Appreciations", "StatusId", c => c.Int());
            DropColumn("dbo.Appreciations", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appreciations", "CreatedBy", c => c.String());
            DropColumn("dbo.Appreciations", "StatusId");
            DropColumn("dbo.Appreciations", "SourceUserId");
            DropTable("dbo.Status");
            DropTable("dbo.Responses");
            DropTable("dbo.Reasons");
            DropTable("dbo.AppreciationTargets");
            CreateIndex("dbo.AppreciationReasons", "AppreciationId");
            CreateIndex("dbo.AppreciationAgrees", "AppreciationId");
            AddForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations", "AppreciationId", cascadeDelete: true);
            AddForeignKey("dbo.AppreciationAgrees", "AppreciationId", "dbo.Appreciations", "AppreciationId", cascadeDelete: true);
        }
    }
}
