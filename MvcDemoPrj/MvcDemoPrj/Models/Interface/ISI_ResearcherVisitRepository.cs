using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MvcDemoPrj.Models.Interface
{
    public interface ISI_ResearcherVisitRepository: IDisposable
    {
        void Create(SI_ResearcherVisit instance);
        void Update(SI_ResearcherVisit instance);
        void Delete(SI_ResearcherVisit instance);
        SI_ResearcherVisit Get(decimal Seq);
        //IQueryable<SI_ResearcherVisit> GetAll();
        void SaveChanges();
    }
}
