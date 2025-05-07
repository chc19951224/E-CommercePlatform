namespace E_CommercePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoriesTableAndProductsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        AssociatedCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.AssociatedCategory_Id)
                .Index(t => t.AssociatedCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "AssociatedCategory_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "AssociatedCategory_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
