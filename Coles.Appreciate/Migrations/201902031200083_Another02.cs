namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Another02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appreciations",
                c => new
                    {
                        AppreciationId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.AppreciationId);
            
            CreateTable(
                "dbo.AppreciationReasons",
                c => new
                    {
                        AppreciationId = c.Int(nullable: false),
                        ReasonId = c.Int(nullable: false),
                        created_by = c.String(),
                        create_date_time = c.DateTime(),
                        mod_date_time = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.AppreciationId, t.ReasonId })
                .ForeignKey("dbo.Appreciations", t => t.AppreciationId, cascadeDelete: true)
                .Index(t => t.AppreciationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations");
            DropIndex("dbo.AppreciationReasons", new[] { "AppreciationId" });
            DropTable("dbo.AppreciationReasons");
            DropTable("dbo.Appreciations");
        }
    }
}
