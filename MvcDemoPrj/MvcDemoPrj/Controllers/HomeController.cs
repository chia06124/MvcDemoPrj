using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemoPrj.Models;
using System.Collections;
using MvcDemoPrj.Models.ViewModel;
using MvcDemoPrj.DAL;
using System.Net;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity;
using System.Web.UI.WebControls;
using MvcDemoPrj.Models.Interface;
using MvcDemoPrj.Models.Repository;
namespace MvcDemoPrj.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<SI_ResearcherVisit> ResearcherVisitRepository;
        private readonly IRepository<SI_StocksReport> SIReportRepository;
        private readonly IRepository<sysCodeMap> sysCodeMapRepository;
        public HomeController()
        {

            this.ResearcherVisitRepository = new GenericRepository<SI_ResearcherVisit>();
            this.SIReportRepository = new GenericRepository<SI_StocksReport>();
            this.sysCodeMapRepository = new GenericRepository<sysCodeMap>();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //防止跨網站偽造請求攻擊
        public ActionResult Delete(int Seq, string ReportType)
        {

            SI_ResearcherVisit visit = ResearcherVisitRepository.Get( Seq);
            ResearcherVisitRepository.Delete(visit);

            try
            {
                if (ReportType.Equals("2") || ReportType.Equals("3"))
                {
                    SI_StocksReport Stocks = SIReportRepository.Get(Seq);
                    SIReportRepository.Delete(Stocks);
                }

            }
            catch (Exception ex)
            {
                TempData["SuccessYN"] = "刪除失敗";
                return View("Index");
                throw;
            }
            TempData["SuccessYN"] = "刪除成功";
            return RedirectToAction("Index");
        }


        public ActionResult Delete(decimal Seq)
        {
                CreateNewViewModel CreateNewViewModel = new CreateNewViewModel();
                SI_ResearcherVisit VisitTemp = ResearcherVisitRepository.Get(Seq);
                if (VisitTemp == null)
                {
                    return HttpNotFound(); //404查無此頁面
                }
                CreateSelectList();
                CreateNewViewModel.DataDate = VisitTemp.DataDate;
                CreateNewViewModel.CompanyId = VisitTemp.CompanyId;
                CreateNewViewModel.CompanyName = VisitTemp.CompanyName;
                CreateNewViewModel.ReportType = VisitTemp.ReportType;
                CreateNewViewModel.EmpName = VisitTemp.EmpName;
                CreateNewViewModel.CreateDate = VisitTemp.CreateDate;
                CreateNewViewModel.CreateUserId = VisitTemp.CreateUserId;
                if (CreateNewViewModel.ReportType.Equals("2") || CreateNewViewModel.ReportType.Equals("3"))
                {
                    SI_StocksReport ReportTemp = SIReportRepository.Get(Seq);
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
                }
                return View(CreateNewViewModel);

        }


        public ActionResult Edit(decimal Seq)
        {
            
                CreateNewViewModel CreateNewViewModel = new CreateNewViewModel();
                SI_ResearcherVisit VisitTemp = ResearcherVisitRepository.Get(Seq);
                if (VisitTemp == null)
                {
                    return HttpNotFound(); //404查無此頁面
                }
                CreateSelectList();
                CreateNewViewModel.DataDate = VisitTemp.DataDate;
                CreateNewViewModel.CompanyId = VisitTemp.CompanyId;
                CreateNewViewModel.CompanyName = VisitTemp.CompanyName;
                CreateNewViewModel.ReportType = VisitTemp.ReportType;
                CreateNewViewModel.EmpName = VisitTemp.EmpName;
                CreateNewViewModel.CreateDate = VisitTemp.CreateDate;
                CreateNewViewModel.CreateUserId = VisitTemp.CreateUserId;
                if (CreateNewViewModel.ReportType.Equals("2") || CreateNewViewModel.ReportType.Equals("3"))
                {
                    SI_StocksReport ReportTemp = SIReportRepository.Get(Seq);
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
                }
                return View(CreateNewViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //防止跨網站偽造請求攻擊
        public ActionResult Edit(CreateNewViewModel CreateNewViewModel)
        {
            using (var db = new FirstModel())
            {
                SI_ResearcherVisit visit = ResearcherVisitRepository.Get(CreateNewViewModel.Seq);
                try
                {
                    visit.Seq = CreateNewViewModel.Seq;
                    visit.DataDate = CreateNewViewModel.DataDate;
                    visit.CompanyId = CreateNewViewModel.CompanyId;
                    visit.CompanyName = CreateNewViewModel.CompanyName;
                    visit.ReportType = CreateNewViewModel.ReportType;
                    visit.EmpName = CreateNewViewModel.EmpName;
                    visit.CreateDate = DateTime.Now;
                    visit.CreateUserId = "01520";
                    ResearcherVisitRepository.Update(visit);

                    if (CreateNewViewModel.ReportType.Equals("2") || CreateNewViewModel.ReportType.Equals("3"))
                    {
                        SI_StocksReport Stocks = SIReportRepository.Get(CreateNewViewModel.Seq);
                        if (Stocks == null)
                        {
                            if (CreateNewViewModel.ReportType_BS.Equals("K") || CreateNewViewModel.ReportType_BS.Equals("S"))
                            {
                                ModelState.Remove("Buy_Price");
                                ModelState.Remove("Targetprice");
                            }
                            else if (CreateNewViewModel.ReportType_BS.Equals("R"))
                            {
                                ModelState.Remove("Buy_Price");
                                ModelState.Remove("Sell_Price");
                                ModelState.Remove("Targetprice");
                                ModelState.Remove("Reason");
                            }
                            else if (CreateNewViewModel.ReportType_BS.Equals("B"))
                            {
                                ModelState.Remove("Sell_Price");
                            }
                            if (ModelState.IsValid)
                            {
                                Stocks = new SI_StocksReport();
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
                                SIReportRepository.Create(Stocks);
                                TempData["SuccessYN"] = "修改成功";
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            if (CreateNewViewModel.ReportType_BS.Equals("K") || CreateNewViewModel.ReportType_BS.Equals("S"))
                            {
                                ModelState.Remove("Buy_Price");
                                ModelState.Remove("Targetprice");
                            }
                            else if (CreateNewViewModel.ReportType_BS.Equals("R"))
                            {
                                ModelState.Remove("Buy_Price");
                                ModelState.Remove("Sell_Price");
                                ModelState.Remove("Targetprice");
                                ModelState.Remove("Reason");
                            }
                            else if (CreateNewViewModel.ReportType_BS.Equals("B"))
                            {
                                ModelState.Remove("Sell_Price");
                            }
                            if (ModelState.IsValid)
                            {
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
                                TempData["SuccessYN"] = "修改成功";
                                return RedirectToAction("Index");
                            }
                        }
                    }
                    else
                    {
                        SI_StocksReport Stocks = SIReportRepository.Get (CreateNewViewModel.Seq);
                        if (Stocks != null)
                        {
                            SIReportRepository.Delete(Stocks);
                        }

                    }
                    TempData["SuccessYN"] = "修改成功";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    CreateSelectList();
                    TempData["SuccessYN"] = "修改失敗";
                    return View(CreateNewViewModel);
                    throw;

                }
            }

        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index(string startDate, string EndDate, string EmpId)
        {
            using (var db = new FirstModel())
            {
                var today = DateTime.Today;

                var query = (from b in db.SI_ResearcherVisit
                             join Suser in db.SA_User on b.CreateUserId equals Suser.UserId
                             join codemap in db.sysCodeMap on b.ReportType equals codemap.Item_Code
                             where codemap.Class_Name == "ReportType"
                             select new
                             {
                                 Seq = b.Seq,
                                 DataDate = b.DataDate,
                                 CompanyId = b.CompanyId,
                                 CompanyName = b.CompanyName,
                                 Item_Name = codemap.Item_Name,
                                 EmpName = b.EmpName,
                                 CreateDate = b.CreateDate,
                                 UserName = Suser.UserName,
                                 CreateUserID = b.CreateUserId
                             }).ToList()
                             .Select(x => new viewModel1
                             {
                                 Seq = x.Seq,
                                 DataDate = x.DataDate,
                                 CompanyId = x.CompanyId,
                                 CompanyName = x.CompanyName,
                                 Item_Name = x.Item_Name,
                                 EmpName = x.EmpName,
                                 CreateDate = x.CreateDate.ToString("yyyy/MM/dd"),
                                 UserName = x.UserName,
                                 CreateUserID = x.CreateUserID
                             }).ToList();

                if (!string.IsNullOrEmpty(EmpId))
                {

                    query = query.Where(x => x.CreateUserID == EmpId).ToList();
                }

                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(EndDate))
                {
                    query = query.Where(x => x.DataDate.CompareTo(startDate) >= 0 && x.DataDate.CompareTo(EndDate) <= 0).ToList();
                }
                var EmpList = (from b in db.SA_User select new EmpViewModel { UserIdTemp = b.UserId, UserNameTemp = b.UserName }).ToList();
                ViewBag.EmpList = EmpList;
                return View(query);
            }
        }

        public void CreateSelectList()
        {
                try
                {
                    //報告類別
                    var ReportList = (from b in this.sysCodeMapRepository.GetAll() where b.Class_Name == "ReportType" select new ReportTypeViewModel { Item_Code = b.Item_Code, Item_Name = b.Item_Name }).ToList();
                    List<SelectListItem> items = new List<SelectListItem>();
                    foreach (var temp in ReportList)
                    {
                        items.Add(new SelectListItem()
                        {
                            Text = temp.Item_Name.ToString(),
                            Value = temp.Item_Code
                        });
                    }
                    ViewBag.Report = items;

                    //個股報告類別
                    var ReportType_BSList = (from b in this.sysCodeMapRepository.GetAll() where b.Class_Name == "ReportType_BSR" select new ReportTypeViewModel { Item_Code = b.Item_Code, Item_Name = b.Item_Name }).ToList();
                    List<SelectListItem> itemsReportType_BSList = new List<SelectListItem>();
                    foreach (var temp in ReportType_BSList)
                    {
                        itemsReportType_BSList.Add(new SelectListItem()
                        {
                            Text = temp.Item_Name.ToString(),
                            Value = temp.Item_Code
                        });
                    }
                    ViewBag.ReportTypeTemp_BS = itemsReportType_BSList;

                    //推薦理由
                    var ReportTypeMemoList = (from b in this.sysCodeMapRepository.GetAll() where b.Class_Name == "Reason" select new ReportTypeViewModel { Item_Code = b.Item_Code, Item_Name = b.Item_Name }).ToList();
                    ViewBag.ReportTypeMemoList = ReportTypeMemoList;

                    ViewBag.CreateDate = DateTime.Now.ToString("yyyy/MM/dd");
                }
                catch (Exception ex)
                {
                    throw;
                }
            //}
        }

        public ActionResult Create()
        {
            CreateSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //防止跨網站偽造請求攻擊
        public ActionResult Create(CreateNewViewModel CreateNewViewModel)
        {
            SI_ResearcherVisit visit = new SI_ResearcherVisit();
            var num = ResearcherVisitRepository.GetAll().Select (x=>x.Seq ).Max ()+1;
            try
            {
                if (CreateNewViewModel.ReportType.Equals("2") || CreateNewViewModel.ReportType.Equals("3"))
                {
                    SI_StocksReport Stocks = new SI_StocksReport();
                    System.Diagnostics.Debug.Write(CreateNewViewModel.PBR);
                    if (CreateNewViewModel.ReportType_BS.Equals("K") || CreateNewViewModel.ReportType_BS.Equals("S"))
                    {
                        ModelState.Remove("Buy_Price");
                        ModelState.Remove("Targetprice");
                    }
                    else if (CreateNewViewModel.ReportType_BS.Equals("R"))
                    {
                        ModelState.Remove("Buy_Price");
                        ModelState.Remove("Sell_Price");
                        ModelState.Remove("Targetprice");
                        ModelState.Remove("Reason");
                    }
                    else if (CreateNewViewModel.ReportType_BS.Equals("B"))
                    {
                        ModelState.Remove("Sell_Price");
                    }
                    if (ModelState.IsValid)
                    {
                        visit.Seq = num;
                        visit.DataDate = CreateNewViewModel.DataDate;
                        visit.CompanyId = CreateNewViewModel.CompanyId;
                        visit.CompanyName = CreateNewViewModel.CompanyName;
                        visit.ReportType = CreateNewViewModel.ReportType;
                        visit.EmpName = CreateNewViewModel.EmpName;
                        visit.CreateDate = DateTime.Now;
                        visit.CreateUserId = "01520";
                        ResearcherVisitRepository.Create(visit);

                        Stocks.Seq = num;
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
                        TempData["SuccessYN"] = "新增成功";
                        return RedirectToAction("Create");
                    }

                }
                else
                {
                    visit.Seq = num;
                    visit.DataDate = CreateNewViewModel.DataDate;
                    visit.CompanyId = CreateNewViewModel.CompanyId;
                    visit.CompanyName = CreateNewViewModel.CompanyName;
                    visit.ReportType = CreateNewViewModel.ReportType;
                    visit.EmpName = CreateNewViewModel.EmpName;
                    visit.CreateDate = DateTime.Now;
                    visit.CreateUserId = "01520";
                    ResearcherVisitRepository.Create(visit);
                    TempData["SuccessYN"] = "新增成功";
                    return RedirectToAction("Create");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            CreateSelectList();
            TempData["SuccessYN"] = "新增失敗";
            return View(CreateNewViewModel);
        }


        public ActionResult ListView()
        {

            using (var db = new FirstModel())
            {
                var query = from b in db.SI_ResearcherVisit
                            select b;

                foreach (var item in query)
                {

                    System.Diagnostics.Debug.Write(item.CompanyName);

                }
                return View(query.ToList());
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}