namespace HomeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationToOwnerPropertyAndValidationMessagesInUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RelationToOwner", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "RelationToOwner");
        }
    }
}
