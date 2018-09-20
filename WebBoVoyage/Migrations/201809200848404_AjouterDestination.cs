namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjouterDestination : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Destination");
        }
    }
}
