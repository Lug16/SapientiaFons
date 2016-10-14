namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityModels", "SubjectId", "dbo.SubjectModels");
            DropIndex("dbo.ActivityModels", new[] { "SubjectId" });
            DropTable("dbo.ActivityModels");
        }
    }
}
