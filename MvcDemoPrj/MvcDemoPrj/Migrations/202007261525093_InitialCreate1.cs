namespace MvcDemoPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SI_ResearcherVisit", "StocksReport_Seq", "dbo.SI_StocksReport");
            DropIndex("dbo.SI_ResearcherVisit", new[] { "StocksReport_Seq" });
            DropColumn("dbo.SI_ResearcherVisit", "StocksReport_Seq");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SI_ResearcherVisit", "StocksReport_Seq", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.SI_ResearcherVisit", "StocksReport_Seq");
            AddForeignKey("dbo.SI_ResearcherVisit", "StocksReport_Seq", "dbo.SI_StocksReport", "Seq");
        }
    }
}
