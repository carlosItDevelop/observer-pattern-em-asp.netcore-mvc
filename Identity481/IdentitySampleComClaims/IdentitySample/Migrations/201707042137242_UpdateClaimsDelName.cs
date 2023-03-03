namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClaimsDelName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetClaims", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetClaims", "Type", c => c.String(nullable: false));
        }
    }
}
