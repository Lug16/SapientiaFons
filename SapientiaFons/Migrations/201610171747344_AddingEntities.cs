namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
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
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 4),
                        Location = c.String(nullable: false, maxLength: 2083),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Activities", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Materials", new[] { "SubjectId" });
            DropIndex("dbo.Subjects", new[] { "UserId" });
            DropIndex("dbo.Activities", new[] { "SubjectId" });
            DropTable("dbo.Materials");
            DropTable("dbo.Subjects");
            DropTable("dbo.Activities");
        }
    }
}
