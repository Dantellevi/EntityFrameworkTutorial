namespace Practic_many_to_Many.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coach = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamPlayers",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        Player_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.Player_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamPlayers", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.TeamPlayers", "Team_Id", "dbo.Teams");
            DropIndex("dbo.TeamPlayers", new[] { "Player_Id" });
            DropIndex("dbo.TeamPlayers", new[] { "Team_Id" });
            DropTable("dbo.TeamPlayers");
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}
