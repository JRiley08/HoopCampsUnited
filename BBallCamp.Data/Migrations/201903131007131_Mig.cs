namespace BBallCamp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CampRating", "Rater_RaterID", "dbo.Rater");
            DropIndex("dbo.CampRating", new[] { "Rater_RaterID" });
            RenameColumn(table: "dbo.CampRating", name: "Rater_RaterID", newName: "RaterID");
            AlterColumn("dbo.CampRating", "RaterID", c => c.Int(nullable: false));
            CreateIndex("dbo.CampRating", "RaterID");
            AddForeignKey("dbo.CampRating", "RaterID", "dbo.Rater", "RaterID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampRating", "RaterID", "dbo.Rater");
            DropIndex("dbo.CampRating", new[] { "RaterID" });
            AlterColumn("dbo.CampRating", "RaterID", c => c.Int());
            RenameColumn(table: "dbo.CampRating", name: "RaterID", newName: "Rater_RaterID");
            CreateIndex("dbo.CampRating", "Rater_RaterID");
            AddForeignKey("dbo.CampRating", "Rater_RaterID", "dbo.Rater", "RaterID");
        }
    }
}
