namespace PhotoKiosk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroups : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.People", new[] { "PhotoID" });
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        IsGroupHead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.PersonId);
            
            CreateIndex("dbo.People", "PhotoId");
            DropColumn("dbo.People", "MiddleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "MiddleName", c => c.String(maxLength: 100));
            DropForeignKey("dbo.GroupMembers", "PersonId", "dbo.People");
            DropForeignKey("dbo.GroupMembers", "GroupId", "dbo.Groups");
            DropIndex("dbo.People", new[] { "PhotoId" });
            DropIndex("dbo.GroupMembers", new[] { "PersonId" });
            DropIndex("dbo.GroupMembers", new[] { "GroupId" });
            DropTable("dbo.GroupMembers");
            DropTable("dbo.Groups");
            CreateIndex("dbo.People", "PhotoID");
        }
    }
}
