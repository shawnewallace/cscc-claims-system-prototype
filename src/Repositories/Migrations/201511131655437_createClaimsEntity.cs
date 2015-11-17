namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createClaimsEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "app.claims",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        Notes = c.String(),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenLastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("app.claims");
        }
    }
}
