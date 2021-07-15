namespace HomeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Room = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Room = c.String(),
                        Type = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lights");
            DropTable("dbo.Doors");
            DropTable("dbo.Devices");
        }
    }
}
