namespace BBallCamp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampRating",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        RaterID = c.Int(nullable: false),
                        CampID = c.Int(nullable: false),
                        OverallRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivityRating = c.Int(nullable: false),
                        CoachingRating = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Camp", t => t.CampID, cascadeDelete: true)
                .ForeignKey("dbo.Rater", t => t.RaterID, cascadeDelete: true)
                .Index(t => t.RaterID)
                .Index(t => t.CampID);
            
            CreateTable(
                "dbo.Camp",
                c => new
                    {
                        CampID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        CampName = c.String(nullable: false),
                        CampCity = c.String(nullable: false),
                        CampState = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CampID);
            
            CreateTable(
                "dbo.Rater",
                c => new
                    {
                        RaterID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Username = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RaterID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CampRating", "RaterID", "dbo.Rater");
            DropForeignKey("dbo.CampRating", "CampID", "dbo.Camp");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CampRating", new[] { "CampID" });
            DropIndex("dbo.CampRating", new[] { "RaterID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Rater");
            DropTable("dbo.Camp");
            DropTable("dbo.CampRating");
        }
    }
}