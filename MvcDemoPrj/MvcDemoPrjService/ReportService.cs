using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemoPrjService.Interface;
using MvcDemoPrj.SQLModel.Models;
using MvcDemoPrj.SQLModel.ViewModel;
using MvcDemoPrj.SQLModel.Repository;
using MvcDemoPrj.SQLModel.Interface;

namespace MvcDemoPrjService
{
   public  class ReportService : IReportService
    {
        private readonly IRepository<SI_StocksReport> SIReportRepository = new GenericRepository<SI_StocksReport>();
        private readonly IRepository<SI_ResearcherVisit> ResearcherVisitRepository = new GenericRepository<SI_ResearcherVisit>();
        public void Create(CreateNewViewModel CreateNewViewModel)
        {
            //var num = ResearcherVisitRepository.GetAll().Select(x => x.Seq).Max() ;
            SI_StocksReport Stocks = new SI_StocksReport();
            Stocks.Seq = CreateNewViewModel.Seq ;
            Stocks.CompanyId = CreateNewViewModel.CompanyId;
            Stocks.CompanyName = CreateNewViewModel.CompanyName;
            Stocks.CapitalStock = CreateNewViewModel.CapitalStock;
            Stocks.ClosePrice = CreateNewViewModel.ClosePrice;
            Stocks.Buy_Price = CreateNewViewModel.Buy_Price;
            Stocks.Sell_Price = CreateNewViewModel.Sell_Price;
            Stocks.Targetprice = CreateNewViewModel.Targetprice;
            if (CreateNewViewModel.PER == null)
            {
                Stocks.PER = 0;
            }
            else
            {
                Stocks.PER = CreateNewViewModel.PER;
            }

            if (CreateNewViewModel.PBR == null)
            {
                Stocks.PBR = 0;
            }
            else
            {
                Stocks.PBR = CreateNewViewModel.PBR;
            }

            if (CreateNewViewModel.EPS_ThisYear == null)
            {
                Stocks.EPS_ThisYear = 0;
            }
            else
            {
                Stocks.EPS_ThisYear = CreateNewViewModel.EPS_ThisYear;
            }

            if (CreateNewViewModel.EPS_NextYear == null)
            {
                Stocks.EPS_NextYear = 0;
            }
            else
            {
                Stocks.EPS_NextYear = CreateNewViewModel.EPS_NextYear;
            }


            Stocks.Reason = CreateNewViewModel.Reason;
            Stocks.ReportType_BS = CreateNewViewModel.ReportType_BS;
            Stocks.Flag = "Y";
            Stocks.Next_Flag = "E";
            Stocks.CreateUser = "01520";
            Stocks.CreateDate = DateTime.Now;
            SIReportRepository.Create(Stocks);
        }

        public void Update(CreateNewViewModel CreateNewViewModel)
        {
            SI_StocksReport Stocks = SIReportRepository.Get(CreateNewViewModel.Seq);
            Stocks.Seq = CreateNewViewModel.Seq;
            Stocks.CompanyId = CreateNewViewModel.CompanyId;
            Stocks.CompanyName = CreateNewViewModel.CompanyName;
            Stocks.CapitalStock = CreateNewViewModel.CapitalStock;
            Stocks.ClosePrice = CreateNewViewModel.ClosePrice;
            Stocks.Buy_Price = CreateNewViewModel.Buy_Price;
            Stocks.Sell_Price = CreateNewViewModel.Sell_Price;
            Stocks.Targetprice = CreateNewViewModel.Targetprice;

            if (CreateNewViewModel.PER == null)
            {
                Stocks.PER = 0;
            }
            else
            {
                Stocks.PER = CreateNewViewModel.PER;
            }

            if (CreateNewViewModel.PBR == null)
            {
                Stocks.PBR = 0;
            }
            else
            {
                Stocks.PBR = CreateNewViewModel.PBR;
            }

            if (CreateNewViewModel.EPS_ThisYear == null)
            {
                Stocks.EPS_ThisYear = 0;
            }
            else
            {
                Stocks.EPS_ThisYear = CreateNewViewModel.EPS_ThisYear;
            }

            if (CreateNewViewModel.EPS_NextYear == null)
            {
                Stocks.EPS_NextYear = 0;
            }
            else
            {
                Stocks.EPS_NextYear = CreateNewViewModel.EPS_NextYear;
            }


            Stocks.Reason = CreateNewViewModel.Reason;

            Stocks.ReportType_BS = CreateNewViewModel.ReportType_BS;
            Stocks.Flag = "Y";
            Stocks.Next_Flag = "E";
            Stocks.CreateUser = "01520";
            Stocks.CreateDate = DateTime.Now;
            SIReportRepository.Update(Stocks);
        }
        public void Delete(SI_StocksReport entity)
        {

        }

        public SI_StocksReport Get(decimal SeqID)
        {
            return SIReportRepository.Get(SeqID);
        }

        public CreateNewViewModel GetEntity(SI_StocksReport ReportTemp)
        {
            //SI_StocksReport ReportTemp = this.Get(Seq);
            CreateNewViewModel CreateNewViewModel = new CreateNewViewModel();
            CreateNewViewModel.Seq  = ReportTemp.Seq;
            CreateNewViewModel.CapitalStock = ReportTemp.CapitalStock;
            CreateNewViewModel.Reason = ReportTemp.Reason;
            CreateNewViewModel.ClosePrice = ReportTemp.ClosePrice;
            CreateNewViewModel.PER = ReportTemp.PER;
            CreateNewViewModel.PBR = ReportTemp.PBR;
            CreateNewViewModel.EPS_ThisYear = ReportTemp.EPS_ThisYear;
            CreateNewViewModel.EPS_NextYear = ReportTemp.EPS_NextYear;
            CreateNewViewModel.Targetprice = ReportTemp.Targetprice;
            CreateNewViewModel.ReportType_BS = ReportTemp.ReportType_BS;
            CreateNewViewModel.Flag = ReportTemp.Flag;
            CreateNewViewModel.Buy_Price = ReportTemp.Buy_Price;
            CreateNewViewModel.Sell_Price = ReportTemp.Sell_Price;
            CreateNewViewModel.CreateUser = ReportTemp.CreateUser;
            CreateNewViewModel.Next_Flag = ReportTemp.Next_Flag;
            return (CreateNewViewModel);
        }
    }
}
