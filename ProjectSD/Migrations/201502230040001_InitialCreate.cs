namespace ProjectSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInfo",
                c => new
                    {
                        PersonalInfoID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserID = c.Int(nullable: false),
                        Users_UsersID = c.Int(),
                    })
                .PrimaryKey(t => t.PersonalInfoID)
                .ForeignKey("dbo.Users", t => t.Users_UsersID)
                .Index(t => t.Users_UsersID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsersID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UsersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalInfo", "Users_UsersID", "dbo.Users");
            DropIndex("dbo.PersonalInfo", new[] { "Users_UsersID" });
            DropTable("dbo.Users");
            DropTable("dbo.PersonalInfo");
        }
    }
}
