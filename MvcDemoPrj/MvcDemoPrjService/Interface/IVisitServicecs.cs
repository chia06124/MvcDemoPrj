using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemoPrj.SQLModel.Models;
using MvcDemoPrj.SQLModel.ViewModel;
namespace MvcDemoPrjService.Interface
{
    interface IVisitServicecs
    {
        void Create(CreateNewViewModel CreateNewViewModel);
        void Update(CreateNewViewModel CreateNewViewModel);
        void Delete(SI_ResearcherVisit entity);
        List<viewModel1> GetAll(string startDate, string EndDate, string EmpId);
        SI_ResearcherVisit Get(decimal SeqID);
        CreateNewViewModel GetEntity(SI_ResearcherVisit entity);
    }
}
