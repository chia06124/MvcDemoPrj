using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoPrj.Models.Interface
{
    interface ISI_SysCodeMapRepository : IDisposable
    {
        void Create(sysCodeMap instance);
        void Update(sysCodeMap instance);
        void Delete(sysCodeMap instance);
        sysCodeMap Get(decimal Seq);
        //IQueryable<SI_StocksReport> GetAll();
        void SaveChanges();
    }
}
