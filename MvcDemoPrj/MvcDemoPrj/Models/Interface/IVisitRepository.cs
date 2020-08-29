using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemoPrj.Models.ViewModel;
namespace MvcDemoPrj.Models.Interface
{
    public interface IVisitRepository
    {
        void Create(CreateNewViewModel CreateNewViewModel);

        void Update(CreateNewViewModel CreateNewViewModel);

        void Delete(int Seq);

        CreateNewViewModel Get(int Seq);

        IQueryable<CreateNewViewModel> GetAll();

        void SaveChanges();
    }
}
