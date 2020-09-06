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
   public class VisitService: IVisitServicecs
    {
        private readonly IRepository<SI_ResearcherVisit> ResearcherVisitRepository= new GenericRepository<SI_ResearcherVisit>();
        private readonly IRepository<sysCodeMap> sysCodeMapRepository = new GenericRepository<sysCodeMap>();
        private readonly IRepository<SA_User> SAUserRepository = new GenericRepository<SA_User>();

        public void Create(CreateNewViewModel CreateNewViewModel)
        {
            SI_ResearcherVisit visit = new SI_ResearcherVisit();
            var num = ResearcherVisitRepository.GetAll().Select(x => x.Seq).Max() + 1;
            visit.Seq = num;
            visit.DataDate = CreateNewViewModel.DataDate;
            visit.CompanyId = CreateNewViewModel.CompanyId;
            visit.CompanyName = CreateNewViewModel.CompanyName;
            visit.ReportType = CreateNewViewModel.ReportType;
            visit.EmpName = CreateNewViewModel.EmpName;
            visit.CreateDate = DateTime.Now;
            visit.CreateUserId = "01520";
            ResearcherVisitRepository.Create(visit);
        }
       public void Update(CreateNewViewModel CreateNewViewModel)
        {
            SI_ResearcherVisit visit = ResearcherVisitRepository.Get(CreateNewViewModel.Seq);
            //visit.Seq = CreateNewViewModel.Seq;//
            visit.DataDate = CreateNewViewModel.DataDate;
            visit.CompanyId = CreateNewViewModel.CompanyId;
            visit.CompanyName = CreateNewViewModel.CompanyName;
            visit.ReportType = CreateNewViewModel.ReportType;
            visit.EmpName = CreateNewViewModel.EmpName;
            visit.CreateDate = DateTime.Now;
            visit.CreateUserId = "01520";
            ResearcherVisitRepository.Update(visit);
        }
        public void Delete(SI_ResearcherVisit entity)
        {

        }
        public List<viewModel1> GetAll(string startDate, string EndDate, string EmpId)
        {
            var today = DateTime.Today;

            var query = (from b in ResearcherVisitRepository.GetAll().ToList()
                         join Suser in SAUserRepository.GetAll().ToList() on b.CreateUserId equals Suser.UserId
                         join codemap in sysCodeMapRepository.GetAll().ToList() on b.ReportType equals codemap.Item_Code
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
            var EmpList = (from b in SAUserRepository.GetAll() select new EmpViewModel { UserIdTemp = b.UserId, UserNameTemp = b.UserName }).ToList();
            //ViewBag.EmpList = EmpList;
            return query;
        }

        public SI_ResearcherVisit Get(decimal SeqID) {
            return ResearcherVisitRepository.Get(SeqID);
        }

        public CreateNewViewModel GetEntity(SI_ResearcherVisit VisitTemp)
        {
            CreateNewViewModel CreateNewViewModel = new CreateNewViewModel();
            CreateNewViewModel.Seq = VisitTemp.Seq ;
            CreateNewViewModel.DataDate = VisitTemp.DataDate;
            CreateNewViewModel.CompanyId = VisitTemp.CompanyId;
            CreateNewViewModel.CompanyName = VisitTemp.CompanyName;
            CreateNewViewModel.ReportType = VisitTemp.ReportType;
            CreateNewViewModel.EmpName = VisitTemp.EmpName;
            CreateNewViewModel.CreateDate = VisitTemp.CreateDate;
            CreateNewViewModel.CreateUserId = VisitTemp.CreateUserId;
            return (CreateNewViewModel);
        }
    }
}
