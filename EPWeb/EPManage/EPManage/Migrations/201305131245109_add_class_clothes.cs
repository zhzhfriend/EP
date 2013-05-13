namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_class_clothes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clothes", "ProductNO", c => c.String(maxLength: 50));
            AddColumn("dbo.Clothes", "Tags", c => c.String(maxLength: 1000));
            DropColumn("dbo.Clothes", "StyleNO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clothes", "StyleNO", c => c.String(maxLength: 50));
            DropColumn("dbo.Clothes", "Tags");
            DropColumn("dbo.Clothes", "ProductNO");
        }
    }
}
