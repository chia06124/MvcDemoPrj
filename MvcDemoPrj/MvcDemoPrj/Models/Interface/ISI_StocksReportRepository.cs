using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoPrj.Models.Interface
{
    public interface ISI_StocksReportRepository: IDisposable
    {
        void Create(SI_StocksReport instance);
        void Update(SI_StocksReport instance);
        void Delete(SI_StocksReport instance);
        SI_StocksReport Get(decimal Seq);
        //IQueryable<SI_StocksReport> GetAll();
        void SaveChanges();
    }
}
