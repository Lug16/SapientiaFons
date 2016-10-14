namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Date = c.DateTime(nullable: false),
                        ShortUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectModels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SubjectModels", new[] { "UserId" });
            DropTable("dbo.SubjectModels");
        }
    }
}
