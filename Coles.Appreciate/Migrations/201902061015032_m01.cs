namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appreciations",
                c => new
                    {
                        AppreciationId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        AppreciationText = c.String(),
                    })
                .PrimaryKey(t => t.AppreciationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appreciations");
        }
    }
}
