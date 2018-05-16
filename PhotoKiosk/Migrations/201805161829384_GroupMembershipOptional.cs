namespace PhotoKiosk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupMembershipOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "GroupId", "dbo.Groups");
            DropIndex("dbo.People", new[] { "GroupId" });
            AlterColumn("dbo.People", "GroupId", c => c.Int());
            CreateIndex("dbo.People", "GroupId");
            AddForeignKey("dbo.People", "GroupId", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "GroupId", "dbo.Groups");
            DropIndex("dbo.People", new[] { "GroupId" });
            AlterColumn("dbo.People", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "GroupId");
            AddForeignKey("dbo.People", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
    }
}
