using MvcDemoPrj.SQLModel.Interface;
using MvcDemoPrj.SQLModel.Models;
using MvcDemoPrj.SQLModel.Repository;
using MvcDemoPrjService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoPrjService
{
   public class SAService: ISAService
    {
        private readonly IRepository<SA_User> saRepository = new GenericRepository<SA_User>();
        public List<SA_User> GetAll()
        {
            var query = (from row in saRepository.GetAll() select row).ToList();
            return query;
        }
    }
}
