namespace EPManageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_session_user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SessionUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SessionId = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                        LastActivityDT = c.DateTime(nullable: false),
                        LoginDT = c.DateTime(nullable: false),
                        RemoteIP = c.String(maxLength: 50),
                        Status = c.String(maxLength: 50),
                        CreateDT = c.DateTime(nullable: false),
                        ModifiedDT = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RealName = c.String(),
                        CreateDT = c.DateTime(nullable: false),
                        ModifiedDT = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SessionUsers", new[] { "UserId" });
            DropForeignKey("dbo.SessionUsers", "UserId", "dbo.Users");
            DropTable("dbo.Users");
            DropTable("dbo.SessionUsers");
        }
    }
}
