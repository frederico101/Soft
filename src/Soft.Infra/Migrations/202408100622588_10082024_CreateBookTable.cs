namespace Soft.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10082024_CreateBookTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Author = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Category = c.String(nullable: false, maxLength: 25, storeType: "nvarchar"),
                        IsRented = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Status = c.String(nullable: false, maxLength: 25, storeType: "nvarchar"),
                        CoverPath = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
