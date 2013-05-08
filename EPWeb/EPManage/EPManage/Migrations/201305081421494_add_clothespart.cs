namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_clothespart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClothesParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        CreateDT = c.DateTime(nullable: false),
                        ModifiedDT = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Parent_Id = c.Int(),
                        ClothType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClothesParts", t => t.Parent_Id)
                .ForeignKey("dbo.ClothesTypes", t => t.ClothType_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.ClothType_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClothesParts", new[] { "ClothType_Id" });
            DropIndex("dbo.ClothesParts", new[] { "Parent_Id" });
            DropForeignKey("dbo.ClothesParts", "ClothType_Id", "dbo.ClothesTypes");
            DropForeignKey("dbo.ClothesParts", "Parent_Id", "dbo.ClothesParts");
            DropTable("dbo.ClothesParts");
        }
    }
}
