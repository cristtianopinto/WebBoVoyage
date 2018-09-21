namespace WebBoVoyage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgenceVoyage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Assurance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeAssurance = c.Int(nullable: false),
                        DossierReservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DossierReservation", t => t.DossierReservation_Id)
                .Index(t => t.DossierReservation_Id);
            
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
                "dbo.Destination",
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
                "dbo.DossierReservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroCarteBancaire = c.String(),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EtatDossierReservation = c.Int(nullable: false),
                        RaisonAnnulationDossier = c.Int(nullable: false),
                        IdVoyage = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                        IdNumeroUnique = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.IdNumeroUnique, cascadeDelete: true)
                .ForeignKey("dbo.Voyages", t => t.IdVoyage, cascadeDelete: true)
                .Index(t => t.IdVoyage)
                .Index(t => t.IdClient)
                .Index(t => t.IdNumeroUnique);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroUnique = c.Int(nullable: false),
                        IdDossierReservation = c.Int(nullable: false),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        DossierReservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DossierReservation", t => t.IdDossierReservation, cascadeDelete: true)
                .ForeignKey("dbo.DossierReservation", t => t.DossierReservation_Id)
                .Index(t => t.IdDossierReservation)
                .Index(t => t.DossierReservation_Id);
            
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
                .ForeignKey("dbo.AgenceVoyage", t => t.IdAgenceVoyage, cascadeDelete: true)
                .ForeignKey("dbo.Destination", t => t.IdDestination, cascadeDelete: true)
                .Index(t => t.IdDestination)
                .Index(t => t.IdAgenceVoyage);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DossierReservation", "IdVoyage", "dbo.Voyages");
            DropForeignKey("dbo.Voyages", "IdDestination", "dbo.Destination");
            DropForeignKey("dbo.Voyages", "IdAgenceVoyage", "dbo.AgenceVoyage");
            DropForeignKey("dbo.Participants", "DossierReservation_Id", "dbo.DossierReservation");
            DropForeignKey("dbo.DossierReservation", "IdNumeroUnique", "dbo.Participants");
            DropForeignKey("dbo.Participants", "IdDossierReservation", "dbo.DossierReservation");
            DropForeignKey("dbo.DossierReservation", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Assurance", "DossierReservation_Id", "dbo.DossierReservation");
            DropIndex("dbo.Voyages", new[] { "IdAgenceVoyage" });
            DropIndex("dbo.Voyages", new[] { "IdDestination" });
            DropIndex("dbo.Participants", new[] { "DossierReservation_Id" });
            DropIndex("dbo.Participants", new[] { "IdDossierReservation" });
            DropIndex("dbo.DossierReservation", new[] { "IdNumeroUnique" });
            DropIndex("dbo.DossierReservation", new[] { "IdClient" });
            DropIndex("dbo.DossierReservation", new[] { "IdVoyage" });
            DropIndex("dbo.Assurance", new[] { "DossierReservation_Id" });
            DropTable("dbo.Voyages");
            DropTable("dbo.Participants");
            DropTable("dbo.DossierReservation");
            DropTable("dbo.Destination");
            DropTable("dbo.Clients");
            DropTable("dbo.Assurance");
            DropTable("dbo.AgenceVoyage");
        }
    }
}
