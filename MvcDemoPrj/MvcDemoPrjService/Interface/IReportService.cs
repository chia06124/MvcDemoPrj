using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemoPrj.SQLModel.Models;
using MvcDemoPrj.SQLModel.ViewModel;
namespace MvcDemoPrjService.Interface
{
    interface IReportService
    {
        void Create(CreateNewViewModel CreateNewViewModel);
        void Update(CreateNewViewModel CreateNewViewModel);
        void Delete(SI_StocksReport entity);
        SI_StocksReport Get(decimal SeqID);
        CreateNewViewModel GetEntity(SI_StocksReport entity);
    }
}
