using System.Collections.Generic;
using System.Linq;
using MvcDemoPrj.SQLModel.Models;
using MvcDemoPrj.SQLModel.Interface;
using MvcDemoPrj.SQLModel.Repository;
using MvcDemoPrjService.Interface;

namespace MvcDemoPrjService
{
    public class SysCodeMapService:ISysCodeMapService
    {
        private readonly IRepository<sysCodeMap> sysCodeMapRepository = new GenericRepository<sysCodeMap>();
        public List<sysCodeMap> GetAll()
        {
            var query = (from row in sysCodeMapRepository.GetAll() select row).ToList();
            return query;
        }
    }
}
