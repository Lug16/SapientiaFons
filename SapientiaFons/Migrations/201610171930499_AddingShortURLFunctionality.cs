namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingShortURLFunctionality : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "ShortUrl", c => c.String(maxLength: 7));
            CreateIndex("dbo.Subjects", "ShortUrl", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subjects", new[] { "ShortUrl" });
            AlterColumn("dbo.Subjects", "ShortUrl", c => c.String());
        }
    }
}
