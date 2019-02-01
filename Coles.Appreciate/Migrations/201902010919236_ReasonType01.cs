namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReasonType01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReasonTypes", "create_date_time", c => c.DateTime());
            AddColumn("dbo.ReasonTypes", "mod_date_time", c => c.DateTime());
            AddColumn("dbo.ReasonTypes", "user_id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReasonTypes", "user_id");
            DropColumn("dbo.ReasonTypes", "mod_date_time");
            DropColumn("dbo.ReasonTypes", "create_date_time");
        }
    }
}
