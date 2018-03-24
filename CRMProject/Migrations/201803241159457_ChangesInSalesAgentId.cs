namespace CRMProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInSalesAgentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusinessCustomers", "SalesAgent_SalesAgentId", "dbo.SalesAgents");
            DropForeignKey("dbo.IndividualCustomers", "SalesAgent_SalesAgentId", "dbo.SalesAgents");
            DropIndex("dbo.BusinessCustomers", new[] { "SalesAgent_SalesAgentId" });
            DropIndex("dbo.IndividualCustomers", new[] { "SalesAgent_SalesAgentId" });
            RenameColumn(table: "dbo.BusinessCustomers", name: "SalesAgent_SalesAgentId", newName: "SalesAgentId");
            RenameColumn(table: "dbo.IndividualCustomers", name: "SalesAgent_SalesAgentId", newName: "SalesAgentId");
            AlterColumn("dbo.BusinessCustomers", "SalesAgentId", c => c.Int(nullable: false));
            AlterColumn("dbo.IndividualCustomers", "SalesAgentId", c => c.Int(nullable: false));
            CreateIndex("dbo.BusinessCustomers", "SalesAgentId");
            CreateIndex("dbo.IndividualCustomers", "SalesAgentId");
            AddForeignKey("dbo.BusinessCustomers", "SalesAgentId", "dbo.SalesAgents", "SalesAgentId", cascadeDelete: true);
            AddForeignKey("dbo.IndividualCustomers", "SalesAgentId", "dbo.SalesAgents", "SalesAgentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndividualCustomers", "SalesAgentId", "dbo.SalesAgents");
            DropForeignKey("dbo.BusinessCustomers", "SalesAgentId", "dbo.SalesAgents");
            DropIndex("dbo.IndividualCustomers", new[] { "SalesAgentId" });
            DropIndex("dbo.BusinessCustomers", new[] { "SalesAgentId" });
            AlterColumn("dbo.IndividualCustomers", "SalesAgentId", c => c.Int());
            AlterColumn("dbo.BusinessCustomers", "SalesAgentId", c => c.Int());
            RenameColumn(table: "dbo.IndividualCustomers", name: "SalesAgentId", newName: "SalesAgent_SalesAgentId");
            RenameColumn(table: "dbo.BusinessCustomers", name: "SalesAgentId", newName: "SalesAgent_SalesAgentId");
            CreateIndex("dbo.IndividualCustomers", "SalesAgent_SalesAgentId");
            CreateIndex("dbo.BusinessCustomers", "SalesAgent_SalesAgentId");
            AddForeignKey("dbo.IndividualCustomers", "SalesAgent_SalesAgentId", "dbo.SalesAgents", "SalesAgentId");
            AddForeignKey("dbo.BusinessCustomers", "SalesAgent_SalesAgentId", "dbo.SalesAgents", "SalesAgentId");
        }
    }
}
