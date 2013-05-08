namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_clothestype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClothesTypes", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClothesTypes", "Name", c => c.String());
        }
    }
}
