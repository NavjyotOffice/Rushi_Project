namespace Pubsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsDML : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentDetails",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 1000),
                        Description = c.String(),
                        Keywords = c.String(),
                        Author = c.String(maxLength: 1000),
                        Image = c.String(maxLength: 1000),
                        URL = c.String(maxLength: 1000),
                        CompanyName = c.String(),
                        HideOnSite = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.String(maxLength: 128),
                        UpdatedById = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        AddressID = c.Int(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        ContentID = c.Int(),
                        EventType = c.String(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Address", t => t.AddressID)
                .ForeignKey("dbo.ContentDetails", t => t.ContentID)
                .Index(t => t.AddressID)
                .Index(t => t.ContentID);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        DetailAddress = c.String(maxLength: 1000),
                        City = c.String(maxLength: 1000),
                        State = c.String(maxLength: 1000),
                        Country = c.String(maxLength: 1000),
                        ZipCode = c.String(maxLength: 10),
                        Contact = c.Int(),
                        Contact1_ContactID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Contact", t => t.Contact1_ContactID)
                .Index(t => t.Contact1_ContactID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 1000),
                        Description = c.String(),
                        WebsiteURL = c.String(maxLength: 1000),
                        LogoImage = c.String(maxLength: 1000),
                        HideOnSite = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedById = c.String(maxLength: 128),
                        UpdatedById = c.String(maxLength: 128),
                        AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Address", t => t.AddressID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 1000),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsDate = c.DateTime(),
                        ContentID = c.Int(),
                        NewsType = c.String(),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.ContentDetails", t => t.ContentID)
                .Index(t => t.ContentID);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourcesID = c.Int(nullable: false, identity: true),
                        ResourceFile = c.String(maxLength: 1000),
                        ContentID = c.Int(),
                        DateTime = c.DateTime(nullable: false),
                        ResourceType = c.String(),
                    })
                .PrimaryKey(t => t.ResourcesID)
                .ForeignKey("dbo.ContentDetails", t => t.ContentID)
                .Index(t => t.ContentID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ContentDetails", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resources", "ContentID", "dbo.ContentDetails");
            DropForeignKey("dbo.News", "ContentID", "dbo.ContentDetails");
            DropForeignKey("dbo.Event", "ContentID", "dbo.ContentDetails");
            DropForeignKey("dbo.Event", "AddressID", "dbo.Address");
            DropForeignKey("dbo.Address", "Contact1_ContactID", "dbo.Contact");
            DropForeignKey("dbo.Company", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Company", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Company", "AddressID", "dbo.Address");
            DropForeignKey("dbo.ContentDetails", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Resources", new[] { "ContentID" });
            DropIndex("dbo.News", new[] { "ContentID" });
            DropIndex("dbo.Company", new[] { "AddressID" });
            DropIndex("dbo.Company", new[] { "UpdatedById" });
            DropIndex("dbo.Company", new[] { "CreatedById" });
            DropIndex("dbo.Address", new[] { "Contact1_ContactID" });
            DropIndex("dbo.Event", new[] { "ContentID" });
            DropIndex("dbo.Event", new[] { "AddressID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ContentDetails", new[] { "UpdatedById" });
            DropIndex("dbo.ContentDetails", new[] { "CreatedById" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Resources");
            DropTable("dbo.News");
            DropTable("dbo.Contact");
            DropTable("dbo.Company");
            DropTable("dbo.Address");
            DropTable("dbo.Event");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ContentDetails");
        }
    }
}
