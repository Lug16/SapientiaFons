namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 4),
                        Location = c.String(nullable: false, maxLength: 2083),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialModels", "SubjectId", "dbo.SubjectModels");
            DropIndex("dbo.MaterialModels", new[] { "SubjectId" });
            DropTable("dbo.MaterialModels");
        }
    }
}
