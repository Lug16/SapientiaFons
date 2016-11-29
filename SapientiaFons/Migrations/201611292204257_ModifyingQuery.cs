namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingQuery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "IsValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "IsValid");
        }
    }
}
