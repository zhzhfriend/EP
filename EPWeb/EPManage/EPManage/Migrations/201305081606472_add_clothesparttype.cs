namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_clothesparttype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClothesPartTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Order = c.Int(nullable: false),
                        ClothesPart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClothesParts", t => t.ClothesPart_Id)
                .Index(t => t.ClothesPart_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClothesPartTypes", new[] { "ClothesPart_Id" });
            DropForeignKey("dbo.ClothesPartTypes", "ClothesPart_Id", "dbo.ClothesParts");
            DropTable("dbo.ClothesPartTypes");
        }
    }
}
