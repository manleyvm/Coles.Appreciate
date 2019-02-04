namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Another09 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations");
            DropPrimaryKey("dbo.Appreciations");
            AlterColumn("dbo.Appreciations", "AppreciationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Appreciations", "AppreciationId");
            AddForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations", "AppreciationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations");
            DropPrimaryKey("dbo.Appreciations");
            AlterColumn("dbo.Appreciations", "AppreciationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Appreciations", "AppreciationId");
            AddForeignKey("dbo.AppreciationReasons", "AppreciationId", "dbo.Appreciations", "AppreciationId", cascadeDelete: true);
        }
    }
}
