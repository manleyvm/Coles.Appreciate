namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppreciationAgrees",
                c => new
                    {
                        AppreciationAgreeId = c.Int(nullable: false, identity: true),
                        AppreciationId = c.Int(nullable: false),
                        UserId = c.String(),
                        ResponseId = c.Int(),
                        mod_date_time = c.DateTime(),
                    })
                .PrimaryKey(t => t.AppreciationAgreeId)
                .ForeignKey("dbo.Appreciations", t => t.AppreciationId, cascadeDelete: true)
                .Index(t => t.AppreciationId);
            
            CreateTable(
                "dbo.AppreciationReasons",
                c => new
                    {
                        AppreciationReasonId = c.Int(nullable: false, identity: true),
                        AppreciationId = c.Int(nullable: false),
                        ReasonId = c.Int(nullable: false),
                        created_by = c.String(),
                        create_date_time = c.DateTime(),
                        mod_date_time = c.DateTime(),
                    })
                .PrimaryKey(t => t.AppreciationReasonId)
                .ForeignKey("dbo.Appreciations", t => t.AppreciationId, cascadeDelete: true)
                .Index(t => t.AppreciationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations");
            DropForeignKey("dbo.AppreciationAgrees", "AppreciationId", "dbo.Appreciations");
            DropIndex("dbo.AppreciationReasons", new[] { "AppreciationId" });
            DropIndex("dbo.AppreciationAgrees", new[] { "AppreciationId" });
            DropTable("dbo.AppreciationReasons");
            DropTable("dbo.AppreciationAgrees");
        }
    }
}
