namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponseTypes01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponseTypes",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        ResponseText = c.String(),
                    })
                .PrimaryKey(t => t.ResponseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResponseTypes");
        }
    }
}
