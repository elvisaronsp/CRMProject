namespace CRMProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessCustomers",
                c => new
                    {
                        BusinessCustomerId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactPhoneNumber = c.String(),
                        City = c.String(),
                        Adress = c.String(),
                        SalesAgent_SalesAgentId = c.Int(),
                    })
                .PrimaryKey(t => t.BusinessCustomerId)
                .ForeignKey("dbo.SalesAgents", t => t.SalesAgent_SalesAgentId)
                .Index(t => t.SalesAgent_SalesAgentId);
            
            CreateTable(
                "dbo.SalesAgents",
                c => new
                    {
                        SalesAgentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Rank = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        SaleValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sales = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesAgentId);
            
            CreateTable(
                "dbo.IndividualCustomers",
                c => new
                    {
                        IndividualCustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        City = c.String(),
                        Adress = c.String(),
                        SalesAgent_SalesAgentId = c.Int(),
                    })
                .PrimaryKey(t => t.IndividualCustomerId)
                .ForeignKey("dbo.SalesAgents", t => t.SalesAgent_SalesAgentId)
                .Index(t => t.SalesAgent_SalesAgentId);
            
            CreateTable(
                "dbo.Realestates",
                c => new
                    {
                        RealestateId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DetailPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RealeseDate = c.DateTime(nullable: false),
                        Available = c.Boolean(nullable: false),
                        Rooms = c.Int(nullable: false),
                        SaleType = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RealestateId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.IndividualCustomers", "SalesAgent_SalesAgentId", "dbo.SalesAgents");
            DropForeignKey("dbo.BusinessCustomers", "SalesAgent_SalesAgentId", "dbo.SalesAgents");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.IndividualCustomers", new[] { "SalesAgent_SalesAgentId" });
            DropIndex("dbo.BusinessCustomers", new[] { "SalesAgent_SalesAgentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Realestates");
            DropTable("dbo.IndividualCustomers");
            DropTable("dbo.SalesAgents");
            DropTable("dbo.BusinessCustomers");
        }
    }
}
