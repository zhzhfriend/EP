namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_clothparttype_children : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClothesPartTypes", "ClothesPartType_Id", c => c.Int());
            AddForeignKey("dbo.ClothesPartTypes", "ClothesPartType_Id", "dbo.ClothesPartTypes", "Id");
            CreateIndex("dbo.ClothesPartTypes", "ClothesPartType_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClothesPartTypes", new[] { "ClothesPartType_Id" });
            DropForeignKey("dbo.ClothesPartTypes", "ClothesPartType_Id", "dbo.ClothesPartTypes");
            DropColumn("dbo.ClothesPartTypes", "ClothesPartType_Id");
        }
    }
}
