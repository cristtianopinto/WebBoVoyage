namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Civilite = c.String(),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Prenom = c.String(maxLength: 30),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Reduction = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "Id", "dbo.Personnes");
            DropForeignKey("dbo.Clients", "Id", "dbo.Personnes");
            DropIndex("dbo.Participants", new[] { "Id" });
            DropIndex("dbo.Clients", new[] { "Id" });
            DropTable("dbo.Participants");
            DropTable("dbo.Clients");
            DropTable("dbo.Personnes");
        }
    }
}
