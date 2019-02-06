namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "StatusCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "StatusCode");
        }
    }
}
