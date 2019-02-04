namespace Coles.Appreciate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Another03 : DbMigration
    {
        public override void Up()
        {
            string sql01 = "CREATE SEQUENCE [dbo].[AppreciateId_Seq] AS INT START WITH 1000 INCREMENT BY 1 NO MAXVALUE NO CYCLE CACHE 10";

            Sql(sql01);

        }
        
        public override void Down()
        {
        }
    }
}
