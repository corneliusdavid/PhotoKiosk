namespace PhotoKiosk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGroupMemberToPerson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupMembers", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupMembers", "PersonId", "dbo.People");
            DropIndex("dbo.GroupMembers", new[] { "GroupId" });
            DropIndex("dbo.GroupMembers", new[] { "PersonId" });
            AddColumn("dbo.People", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Groups", "GroupName");
            CreateIndex("dbo.People", "GroupId");
            AddForeignKey("dbo.People", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            DropTable("dbo.GroupMembers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        IsGroupHead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.People", "GroupId", "dbo.Groups");
            DropIndex("dbo.People", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "GroupName" });
            DropColumn("dbo.People", "GroupId");
            CreateIndex("dbo.GroupMembers", "PersonId");
            CreateIndex("dbo.GroupMembers", "GroupId");
            AddForeignKey("dbo.GroupMembers", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupMembers", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
    }
}
