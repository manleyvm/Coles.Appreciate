namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Another04 : DbMigration
    {
        public override void Up()
        {
            string sqlRaw = "ALTER TABLE dbo.Appreciations ALTER COLUMN AppreciationId int not null";
            Sql(sqlRaw);
        }
        
        public override void Down()
        {
        }
    }
}
