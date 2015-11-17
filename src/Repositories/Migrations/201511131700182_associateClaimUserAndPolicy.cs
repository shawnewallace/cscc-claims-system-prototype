namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class associateClaimUserAndPolicy : DbMigration
    {
        public override void Up()
        {
            AddColumn("app.claims", "PolicyId", c => c.Guid(nullable: false));
            AddColumn("app.claims", "UserId", c => c.String(maxLength: 128));
            CreateIndex("app.claims", "PolicyId");
            CreateIndex("app.claims", "UserId");
            AddForeignKey("app.claims", "PolicyId", "app.policies", "Id", cascadeDelete: true);
            AddForeignKey("app.claims", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("app.claims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("app.claims", "PolicyId", "app.policies");
            DropIndex("app.claims", new[] { "UserId" });
            DropIndex("app.claims", new[] { "PolicyId" });
            DropColumn("app.claims", "UserId");
            DropColumn("app.claims", "PolicyId");
        }
    }
}
