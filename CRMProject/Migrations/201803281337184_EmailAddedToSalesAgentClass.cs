namespace CRMProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAddedToSalesAgentClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesAgents", "Email", c => c.String());
            AlterColumn("dbo.Realestates", "BasePrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Realestates", "DetailPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Realestates", "DetailPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Realestates", "BasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.SalesAgents", "Email");
        }
    }
}
