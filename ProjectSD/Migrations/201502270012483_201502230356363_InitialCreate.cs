namespace ProjectSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201502230356363_InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Board",
                c => new
                    {
                        BoardID = c.Int(nullable: false, identity: true),
                        BoardName = c.String(),
                        BoardCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BoardID);
            
            CreateTable(
                "dbo.BoardMember",
                c => new
                    {
                        BoardMemberID = c.Int(nullable: false, identity: true),
                        DateAdded = c.String(),
                        Board_BoardID = c.Int(),
                        Users_UsersID = c.Int(),
                    })
                .PrimaryKey(t => t.BoardMemberID)
                .ForeignKey("dbo.Board", t => t.Board_BoardID)
                .ForeignKey("dbo.Users", t => t.Users_UsersID)
                .Index(t => t.Board_BoardID)
                .Index(t => t.Users_UsersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoardMember", "Users_UsersID", "dbo.Users");
            DropForeignKey("dbo.BoardMember", "Board_BoardID", "dbo.Board");
            DropIndex("dbo.BoardMember", new[] { "Users_UsersID" });
            DropIndex("dbo.BoardMember", new[] { "Board_BoardID" });
            DropTable("dbo.BoardMember");
            DropTable("dbo.Board");
        }
    }
}
