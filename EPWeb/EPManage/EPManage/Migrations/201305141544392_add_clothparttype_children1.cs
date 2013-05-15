namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_clothparttype_children1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClothesPartTypes", "ClothesPartType_Id", "dbo.ClothesPartTypes");
            DropIndex("dbo.ClothesPartTypes", new[] { "ClothesPartType_Id" });
            AddColumn("dbo.ClothesPartTypes", "Parent_Id", c => c.Int());
            AddForeignKey("dbo.ClothesPartTypes", "Parent_Id", "dbo.ClothesPartTypes", "Id");
            CreateIndex("dbo.ClothesPartTypes", "Parent_Id");
            DropColumn("dbo.ClothesPartTypes", "ClothesPartType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClothesPartTypes", "ClothesPartType_Id", c => c.Int());
            DropIndex("dbo.ClothesPartTypes", new[] { "Parent_Id" });
            DropForeignKey("dbo.ClothesPartTypes", "Parent_Id", "dbo.ClothesPartTypes");
            DropColumn("dbo.ClothesPartTypes", "Parent_Id");
            CreateIndex("dbo.ClothesPartTypes", "ClothesPartType_Id");
            AddForeignKey("dbo.ClothesPartTypes", "ClothesPartType_Id", "dbo.ClothesPartTypes", "Id");
        }
    }
}
