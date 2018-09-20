namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgenceVoyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Continent = c.String(maxLength: 20),
                        Pays = c.String(maxLength: 20),
                        Region = c.String(maxLength: 20),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reduction = c.Single(nullable: false),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAller = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                        PlacesDisponibles = c.Int(nullable: false),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdDestination = c.Int(nullable: false),
                        IdAgenceVoyage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgenceVoyages", t => t.IdAgenceVoyage, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.IdDestination, cascadeDelete: true)
                .Index(t => t.IdDestination)
                .Index(t => t.IdAgenceVoyage);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voyages", "IdDestination", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "IdAgenceVoyage", "dbo.AgenceVoyages");
            DropIndex("dbo.Voyages", new[] { "IdAgenceVoyage" });
            DropIndex("dbo.Voyages", new[] { "IdDestination" });
            DropTable("dbo.Voyages");
            DropTable("dbo.Participants");
            DropTable("dbo.Destinations");
            DropTable("dbo.Clients");
            DropTable("dbo.AgenceVoyages");
        }
    }
}
