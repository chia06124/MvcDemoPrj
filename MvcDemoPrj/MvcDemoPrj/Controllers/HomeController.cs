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
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            using (var db = new Model1())
            {
                //var query = from b in db.SA_User
                //            select b;

                //var query = (from b in db.SA_User select b).ToList();

                var query = (from b in db.SI_ResearcherVisit
                             join Suser in db.SA_User on b.CreateUserId equals Suser.UserId
                             join codemap in db.sysCodeMap on b.ReportType equals codemap.Item_Code
                             where codemap.Class_Name == "ReportType"
                             select new viewModel1 { DataDate = b.DataDate, CompanyId = b.CompanyId, CompanyName = b.CompanyName, Item_Name = codemap.Item_Name, EmpName = b.EmpName, CreateDate = b.CreateDate, UserName = Suser.UserName }).ToList();

                //var query = from b in db.SI_ResearcherVisit
                //            select b;

                //viewModel1 vm = new viewModel1();
                //vm.temp = query;


                return View(query);
            }

            //return View();
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