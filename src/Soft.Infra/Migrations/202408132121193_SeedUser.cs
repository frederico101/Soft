namespace Soft.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users (Id, Username, Password) VALUES (UUID(), 'fred', '123')");
        }
        
        public override void Down()
        {
        }
    }
}
