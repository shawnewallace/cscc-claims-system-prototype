namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNoteEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "app.notes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClaimEntity_ID = c.Guid(nullable: false),
                        AuthorizedUser_Id = c.String(maxLength: 128),
                        Content = c.String(),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenLastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("app.claims", t => t.ClaimEntity_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorizedUser_Id)
                .Index(t => t.ClaimEntity_ID)
                .Index(t => t.AuthorizedUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("app.notes", "AuthorizedUser_Id", "dbo.AspNetUsers");
            DropForeignKey("app.notes", "ClaimEntity_ID", "app.claims");
            DropIndex("app.notes", new[] { "AuthorizedUser_Id" });
            DropIndex("app.notes", new[] { "ClaimEntity_ID" });
            DropTable("app.notes");
        }
    }
}
