namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createAddressEntityAndAssociateWithUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "app.addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        AuthorizedUser_Id = c.String(maxLength: 128),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenLastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorizedUser_Id)
                .Index(t => t.AuthorizedUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("app.addresses", "AuthorizedUser_Id", "dbo.AspNetUsers");
            DropIndex("app.addresses", new[] { "AuthorizedUser_Id" });
            DropTable("app.addresses");
        }
    }
}
