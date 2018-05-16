namespace PhotoKiosk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relationships", "Person1Id", "dbo.People");
            DropForeignKey("dbo.Relationships", "Person2Id", "dbo.People");
            DropForeignKey("dbo.Relationships", "RelationShipTypeId", "dbo.RelationShipTypes");
            DropIndex("dbo.Relationships", new[] { "Person1Id" });
            DropIndex("dbo.Relationships", new[] { "Person2Id" });
            DropIndex("dbo.Relationships", new[] { "RelationShipTypeId" });
            DropTable("dbo.Relationships");
            DropTable("dbo.RelationShipTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RelationShipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationshipName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person1Id = c.Int(nullable: false),
                        Person2Id = c.Int(nullable: false),
                        RelationShipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Relationships", "RelationShipTypeId");
            CreateIndex("dbo.Relationships", "Person2Id");
            CreateIndex("dbo.Relationships", "Person1Id");
            AddForeignKey("dbo.Relationships", "RelationShipTypeId", "dbo.RelationShipTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Relationships", "Person2Id", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Relationships", "Person1Id", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
