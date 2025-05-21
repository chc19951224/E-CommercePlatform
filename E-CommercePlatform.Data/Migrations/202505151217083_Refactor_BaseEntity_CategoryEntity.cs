namespace E_CommercePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactor_BaseEntity_CategoryEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Feature", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Feature", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
            DropColumn("dbo.Categories", "IsFeatured");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "IsFeatured", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "ImageUrl");
            DropColumn("dbo.Products", "Feature");
            DropColumn("dbo.Categories", "Feature");
        }
    }
}
