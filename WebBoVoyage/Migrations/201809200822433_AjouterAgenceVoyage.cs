namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjouterAgenceVoyage : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AgenceVoyage");
        }
    }
}
