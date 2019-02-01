namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReasonTypes",
                c => new
                    {
                        ReasonId = c.Int(nullable: false, identity: true),
                        ReasonText = c.String(),
                    })
                .PrimaryKey(t => t.ReasonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReasonTypes");
        }
    }
}
