namespace SapientiaFons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingMaterialType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Materials", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Materials", "Type", c => c.String(nullable: false, maxLength: 4));
        }
    }
}
