namespace MvcDemoPrj.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MvcDemoPrj.DAL;
    using MvcDemoPrj.Models;

    public partial class NewModel : DbContext
    {
        public NewModel()
            : base("name=NewModel1")
        {
        }

        public virtual DbSet<SA_User> SA_User { get; set; }
        public virtual DbSet<SI_ResearcherVisit> SI_ResearcherVisit { get; set; }
        public virtual DbSet<SI_StocksReport> SI_StocksReport { get; set; }
        public virtual DbSet<sysCodeMap> sysCodeMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SA_User>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.UserRole)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.UserUnit)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.PasswordChangeDate)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.ExpireDate)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.LastLoginHost)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.UserDesc)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.UserEMail)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.IsCancelled)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.PassStatus)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);

            modelBuilder.Entity<SA_User>()
                .Property(e => e.PassUserId)
                .IsUnicode(false);

            modelBuilder.Entity<SI_ResearcherVisit>()
                .Property(e => e.Seq)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SI_ResearcherVisit>()
                .Property(e => e.DataDate)
                .IsUnicode(false);

            modelBuilder.Entity<SI_ResearcherVisit>()
                .Property(e => e.CompanyId)
                .IsUnicode(false);

            modelBuilder.Entity<SI_ResearcherVisit>()
                .Property(e => e.ReportType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SI_ResearcherVisit>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.Seq)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.CapitalStock)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.CompanyId)
                .IsUnicode(false);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.ClosePrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.PER)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.PBR)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.EPS_ThisYear)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.EPS_NextYear)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.Targetprice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.ReportType_BS)
                .IsUnicode(false);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.Flag)
                .IsUnicode(false);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.Buy_Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.Sell_Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<SI_StocksReport>()
                .Property(e => e.Next_Flag)
                .IsUnicode(false);

            modelBuilder.Entity<sysCodeMap>()
                .Property(e => e.Class_Name)
                .IsUnicode(false);

            modelBuilder.Entity<sysCodeMap>()
                .Property(e => e.Item_Code)
                .IsUnicode(false);

            modelBuilder.Entity<sysCodeMap>()
                .Property(e => e.Flag_Usable)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sysCodeMap>()
                .Property(e => e.Memo)
                .IsUnicode(false);
        }
    }
}
