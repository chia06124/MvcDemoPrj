using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemoPrj.Models;
using System.Collections;
using MvcDemoPrj.Models.ViewModel;

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
            using (var db = new Model1())
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SI_ResearcherVisit visit, List<PostCreateViewModel> PostCreateViewModel)
        {
            using (var db = new Model1())
            {
                try
                {
                    
                    var num = db.SI_ResearcherVisit.Select(p => p.Seq).Max()+1;

                    //DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                    //                   System.Globalization.CultureInfo.InvariantCulture);
                    visit.Seq = num;
                    visit.DataDate = PostCreateViewModel[0].DataDate;
                    visit.CompanyId = PostCreateViewModel[0].CompanyId;
                    visit.CompanyName = PostCreateViewModel[0].CompanyName;
                    visit.ReportType = PostCreateViewModel[0].ReportType;
                    visit.EmpName = PostCreateViewModel[0].EmpName;
                    visit.CreateDate = PostCreateViewModel[0].CreateDate;
                    visit.CreateUserId = PostCreateViewModel[0].CreateUserId;
                    db.SI_ResearcherVisit.Add(visit);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult MyAction()
        {
            using (var db = new Model1())
            {
                //var cityList = (from b in db.SA_User select b).ToList();
                var cityList = (from b in db.SA_User select new EmpViewModel { UserIdTemp = b.UserId, UserNameTemp = b.UserName }).ToList();

                ViewBag.CityList = cityList;
            }

            return View();
        }

        public ActionResult ListView()
        {

            using (var db = new Model1())
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