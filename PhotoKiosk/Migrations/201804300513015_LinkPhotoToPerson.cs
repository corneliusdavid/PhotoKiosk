namespace PhotoKiosk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkPhotoToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PhotoID", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "PhotoID");
            AddForeignKey("dbo.People", "PhotoID", "dbo.Photos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PhotoID", "dbo.Photos");
            DropIndex("dbo.People", new[] { "PhotoID" });
            DropColumn("dbo.People", "PhotoID");
        }
    }
}
