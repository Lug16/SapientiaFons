namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        SubjectId = c.Int(nullable: false),
                        HypothesisId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hypothesis", t => t.HypothesisId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.HypothesisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "HypothesisId", "dbo.Hypothesis");
            DropIndex("dbo.Questions", new[] { "HypothesisId" });
            DropIndex("dbo.Questions", new[] { "SubjectId" });
            DropTable("dbo.Questions");
        }
    }
}
