namespace MvcDemoPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SA_User",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 20),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserRole = c.String(nullable: false, maxLength: 20),
                        UserUnit = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 50),
                        PasswordChangeDate = c.String(nullable: false, maxLength: 10),
                        PasswordErrorCount = c.Int(nullable: false),
                        ExpireDate = c.String(nullable: false, maxLength: 10),
                        LastLoginDate = c.DateTime(nullable: false),
                        LastLoginHost = c.String(nullable: false, maxLength: 23),
                        UserDesc = c.String(nullable: false, maxLength: 100),
                        UserEMail = c.String(nullable: false, maxLength: 100),
                        IsCancelled = c.String(nullable: false, maxLength: 1),
                        PassStatus = c.String(nullable: false, maxLength: 1),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserId = c.String(nullable: false, maxLength: 20),
                        PassUserId = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.SI_ResearcherVisit",
                c => new
                    {
                        Seq = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataDate = c.String(nullable: false, maxLength: 20),
                        CompanyId = c.String(nullable: false, maxLength: 8),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        ReportType = c.String(nullable: false, maxLength: 1),
                        EmpName = c.String(nullable: false, maxLength: 20),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserId = c.String(nullable: false, maxLength: 5),
                        StocksReport_Seq = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Seq)
                .ForeignKey("dbo.SI_StocksReport", t => t.StocksReport_Seq)
                .Index(t => t.StocksReport_Seq);
            
            CreateTable(
                "dbo.SI_StocksReport",
                c => new
                    {
                        Seq = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CapitalStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.String(nullable: false, maxLength: 8),
                        CompanyName = c.String(nullable: false, maxLength: 10),
                        Reason = c.String(nullable: false, maxLength: 1000),
                        ClosePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PER = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PBR = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EPS_ThisYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EPS_NextYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Targetprice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReportType_BS = c.String(nullable: false, maxLength: 1),
                        Flag = c.String(nullable: false, maxLength: 1),
                        Buy_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sell_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUser = c.String(nullable: false, maxLength: 5),
                        Next_Flag = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.Seq);
            
            CreateTable(
                "dbo.sysCodeMap",
                c => new
                    {
                        Class_Name = c.String(nullable: false, maxLength: 30),
                        Item_Code = c.String(nullable: false, maxLength: 30),
                        Ch_Name = c.String(nullable: false, maxLength: 50),
                        Item_Name = c.String(nullable: false, maxLength: 50),
                        Seq = c.Int(),
                        Flag_Usable = c.String(nullable: false, maxLength: 10),
                        Memo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.Class_Name, t.Item_Code });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SI_ResearcherVisit", "StocksReport_Seq", "dbo.SI_StocksReport");
            DropIndex("dbo.SI_ResearcherVisit", new[] { "StocksReport_Seq" });
            DropTable("dbo.sysCodeMap");
            DropTable("dbo.SI_StocksReport");
            DropTable("dbo.SI_ResearcherVisit");
            DropTable("dbo.SA_User");
        }
    }
}
