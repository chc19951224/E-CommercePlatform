namespace E_CommercePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesProductsRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "AssociatedCategory_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "AssociatedCategory_Id" });
            RenameColumn(table: "dbo.Products", name: "AssociatedCategory_Id", newName: "AssociatedCategoryId");
            AlterColumn("dbo.Products", "AssociatedCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "AssociatedCategoryId");
            AddForeignKey("dbo.Products", "AssociatedCategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "AssociatedCategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "AssociatedCategoryId" });
            AlterColumn("dbo.Products", "AssociatedCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "AssociatedCategoryId", newName: "AssociatedCategory_Id");
            CreateIndex("dbo.Products", "AssociatedCategory_Id");
            AddForeignKey("dbo.Products", "AssociatedCategory_Id", "dbo.Categories", "Id");
        }
    }
}
