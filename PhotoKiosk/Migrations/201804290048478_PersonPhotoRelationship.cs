namespace PhotoDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonPhotoRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        NickName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoFilename = c.String(nullable: false, maxLength: 255),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person1Id, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.Person2Id, cascadeDelete: false)
                .ForeignKey("dbo.RelationshipTypes", t => t.RelationShipTypeId, cascadeDelete: true)
                .Index(t => t.Person1Id)
                .Index(t => t.Person2Id)
                .Index(t => t.RelationShipTypeId);
            
            CreateTable(
                "dbo.RelationshipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationshipName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Parent')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Child')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Husband')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Wife')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Partner')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Son')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Daughter')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Grandparent')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Grandfather')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Grandmother')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Grandchild')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Grandson')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Granddaughter')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Uncle')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Aunt')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Nephew')");
            Sql("INSERT INTO RelationshipTypes(RelationshipName) VALUES('Neice')");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Relationships", "RelationShipTypeId", "dbo.RelationShipTypes");
            DropForeignKey("dbo.Relationships", "Person2Id", "dbo.People");
            DropForeignKey("dbo.Relationships", "Person1Id", "dbo.People");
            DropIndex("dbo.Relationships", new[] { "RelationShipTypeId" });
            DropIndex("dbo.Relationships", new[] { "Person2Id" });
            DropIndex("dbo.Relationships", new[] { "Person1Id" });
            DropTable("dbo.RelationShipTypes");
            DropTable("dbo.Relationships");
            DropTable("dbo.Photos");
            DropTable("dbo.People");
        }
    }
}
