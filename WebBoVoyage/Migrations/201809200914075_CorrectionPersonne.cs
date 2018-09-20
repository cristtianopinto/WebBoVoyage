namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionPersonne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Id", "dbo.Personnes");
            DropForeignKey("dbo.Participants", "Id", "dbo.Personnes");
            DropIndex("dbo.Clients", new[] { "Id" });
            DropIndex("dbo.Participants", new[] { "Id" });
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Participants");
            AddColumn("dbo.Clients", "Civilite", c => c.String());
            AddColumn("dbo.Clients", "Nom", c => c.String());
            AddColumn("dbo.Clients", "Prenom", c => c.String());
            AddColumn("dbo.Clients", "Adresse", c => c.String());
            AddColumn("dbo.Clients", "Telephone", c => c.String());
            AddColumn("dbo.Clients", "DateNaissance", c => c.DateTime(nullable: false));
            AddColumn("dbo.Participants", "Civilite", c => c.String());
            AddColumn("dbo.Participants", "Nom", c => c.String());
            AddColumn("dbo.Participants", "Prenom", c => c.String());
            AddColumn("dbo.Participants", "Adresse", c => c.String());
            AddColumn("dbo.Participants", "Telephone", c => c.String());
            AddColumn("dbo.Participants", "DateNaissance", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Participants", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.Participants", "Id");
            DropTable("dbo.Personnes");
        }
        
        public override void Down()
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
            
            DropPrimaryKey("dbo.Participants");
            DropPrimaryKey("dbo.Clients");
            AlterColumn("dbo.Participants", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Participants", "DateNaissance");
            DropColumn("dbo.Participants", "Telephone");
            DropColumn("dbo.Participants", "Adresse");
            DropColumn("dbo.Participants", "Prenom");
            DropColumn("dbo.Participants", "Nom");
            DropColumn("dbo.Participants", "Civilite");
            DropColumn("dbo.Clients", "DateNaissance");
            DropColumn("dbo.Clients", "Telephone");
            DropColumn("dbo.Clients", "Adresse");
            DropColumn("dbo.Clients", "Prenom");
            DropColumn("dbo.Clients", "Nom");
            DropColumn("dbo.Clients", "Civilite");
            AddPrimaryKey("dbo.Participants", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            CreateIndex("dbo.Participants", "Id");
            CreateIndex("dbo.Clients", "Id");
            AddForeignKey("dbo.Participants", "Id", "dbo.Personnes", "Id");
            AddForeignKey("dbo.Clients", "Id", "dbo.Personnes", "Id");
        }
    }
}
