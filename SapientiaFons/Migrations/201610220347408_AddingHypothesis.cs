namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingHypothesis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hypothesis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hypothesis", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Hypothesis", new[] { "SubjectId" });
            DropTable("dbo.Hypothesis");
        }
    }
}
