namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClaims : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetClaims", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetClaims", "Type");
        }
    }
}
