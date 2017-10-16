namespace SQL_Operation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLOperationMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comapanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comapanies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "CompanyId", "dbo.Comapanies");
            DropIndex("dbo.Phones", new[] { "CompanyId" });
            DropTable("dbo.Phones");
            DropTable("dbo.Comapanies");
        }
    }
}
