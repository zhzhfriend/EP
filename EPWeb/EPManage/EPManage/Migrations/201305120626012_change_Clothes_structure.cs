namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_Clothes_structure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clothes", "AssessoriesFile", c => c.String(maxLength: 100));
            AddColumn("dbo.Clothes", "ClothesPics", c => c.String(maxLength: 500));
            AddColumn("dbo.Clothes", "ModelVersionPics", c => c.String(maxLength: 500));
            AddColumn("dbo.Clothes", "SampleFile", c => c.String(maxLength: 100));
            AddColumn("dbo.Clothes", "StylePics", c => c.String(maxLength: 500));
            AddColumn("dbo.Clothes", "TechnologyFile", c => c.String(maxLength: 100));
            AddColumn("dbo.Clothes", "ClothesSize", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clothes", "ClothesSize");
            DropColumn("dbo.Clothes", "TechnologyFile");
            DropColumn("dbo.Clothes", "StylePics");
            DropColumn("dbo.Clothes", "SampleFile");
            DropColumn("dbo.Clothes", "ModelVersionPics");
            DropColumn("dbo.Clothes", "ClothesPics");
            DropColumn("dbo.Clothes", "AssessoriesFile");
        }
    }
}
