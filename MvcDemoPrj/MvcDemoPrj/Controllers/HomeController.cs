using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemoPrj.Models;
using System.Collections;
using MvcDemoPrj.Models.ViewModel;
using MvcDemoPrj.DAL;

namespace MvcDemoPrj.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult FUCK()
        {
            return View();
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
                //var tempEmp = (from a in db.SA_User
                //               select a).ToList();
                //ViewBag.tempEmp = new SelectList(items: tempEmp, dataTextField: "UserName", dataValueField: "UserId");

                return View(query);
            }
        }

        public void CreateSelectList()
        {
            using (var db = new FirstModel())
            {
                try
                {
                    //報告類別
                    var ReportList = (from b in db.sysCodeMap where b.Class_Name == "ReportType" select new ReportTypeViewModel { Item_Code = b.Item_Code, Item_Name = b.Item_Name }).ToList();
                    ViewBag.Report = ReportList;
                    //個股報告類別
                    var ReportType_BSList = (from b in db.sysCodeMap where b.Class_Name == "ReportType_BSR" select new ReportTypeViewModel { Item_Code = b.Item_Code, Item_Name = b.Item_Name }).ToList();
                    ViewBag.ReportType_BS = ReportType_BSList;
                    //推薦理由
                    var ReportTypeMemoList = (from b in db.sysCodeMap where b.Class_Name == "Reason" select new ReportTypeViewModel { Item_Code = b.Item_Code, Item_Name = b.Item_Name }).ToList();
                    ViewBag.ReportTypeMemoList = ReportTypeMemoList;

                    ViewBag.CreateDate = DateTime.Now.ToString("yyyy/MM/dd");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
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
            using (var db = new FirstModel())
            {
                SI_ResearcherVisit visit = new SI_ResearcherVisit();
                var num = db.SI_ResearcherVisit.Select(p => p.Seq).Max() + 1;
                try
                {
                    if (CreateNewViewModel.ReportType.Equals("2") || CreateNewViewModel.ReportType.Equals("3"))
                    {
                        SI_StocksReport Stocks = new SI_StocksReport();
                        System.Diagnostics.Debug.Write(CreateNewViewModel.PBR);
                        //ModelState.Remove("PER");
                        //ModelState.Remove("PBR");
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
                            db.SI_ResearcherVisit.Add(visit);
                            db.SaveChanges();


                            Stocks.Seq = num;
                            Stocks.CompanyId = CreateNewViewModel.CompanyId;
                            Stocks.CompanyName = CreateNewViewModel.CompanyName;
                            Stocks.CapitalStock = CreateNewViewModel.CapitalStock;
                            Stocks.ClosePrice = CreateNewViewModel.ClosePrice;
                            Stocks.Buy_Price = CreateNewViewModel.Buy_Price;
                            Stocks.ClosePrice = CreateNewViewModel.ClosePrice;
                            Stocks.Targetprice = CreateNewViewModel.Targetprice;
                            Stocks.Reason = CreateNewViewModel.Reason;
                            if (CreateNewViewModel.PER == null){
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
                            
                            Stocks.ReportType_BS = CreateNewViewModel.ReportType_BS;
                            Stocks.Flag = "Y";
                            Stocks.Next_Flag = "E";
                            Stocks.CreateUser = "01520";
                            Stocks.CreateDate = DateTime.Now;
                            db.SI_StocksReport.Add(Stocks);
                            db.SaveChanges();
                            TempData["SuccessYN"] = "新增成功";
                            return RedirectToAction("Create");
                        }

                    }
                    else
                    {
                        //if (ModelState.IsValid)
                        //{
                            visit.Seq = num;
                            visit.DataDate = CreateNewViewModel.DataDate;
                            visit.CompanyId = CreateNewViewModel.CompanyId;
                            visit.CompanyName = CreateNewViewModel.CompanyName;
                            visit.ReportType = CreateNewViewModel.ReportType;
                            visit.EmpName = CreateNewViewModel.EmpName;
                            visit.CreateDate = DateTime.Now;
                            visit.CreateUserId = "01520";
                            db.SI_ResearcherVisit.Add(visit);
                            db.SaveChanges();
                            TempData["SuccessYN"] = "新增成功";
                            return RedirectToAction("Create");
                        //}
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
        }

        public ActionResult MyAction()
        {
            using (var db = new FirstModel())
            {
                //var cityList = (from b in db.SA_User select b).ToList();
                var cityList = (from b in db.SA_User select new EmpViewModel { UserIdTemp = b.UserId, UserNameTemp = b.UserName }).ToList();

                ViewBag.CityList = cityList;
            }

            return View();
        }

        public ActionResult ListView()
        {

            using (var db = new FirstModel())
            {
                //var query = from b in db.SI_ResearcherVisit 
                //            join Suser in db.SA_User on b.CreateUserId equals Suser.UserId
                //            select new { b.DataDate,b.CompanyId,b.CompanyName,b.ReportType,Suser.UserName, b.CreateDate};

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