namespace PhotoKiosk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonPhotoOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PhotoId", "dbo.Photos");
            DropIndex("dbo.People", new[] { "PhotoId" });
            AlterColumn("dbo.People", "PhotoId", c => c.Int());
            AlterColumn("dbo.Photos", "PhotoFilename", c => c.String(maxLength: 255));
            CreateIndex("dbo.People", "PhotoId");
            AddForeignKey("dbo.People", "PhotoId", "dbo.Photos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PhotoId", "dbo.Photos");
            DropIndex("dbo.People", new[] { "PhotoId" });
            AlterColumn("dbo.Photos", "PhotoFilename", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.People", "PhotoId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "PhotoId");
            AddForeignKey("dbo.People", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
        }
    }
}
