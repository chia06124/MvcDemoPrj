using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemoPrj.SQLModel.ViewModel
{
    public class PostCreateViewModel
    {
        public string DataDate { get; set; }
        
        public string CompanyId { get; set; }

       
        public string CompanyName { get; set; }

       
        public string ReportType { get; set; }

        public string EmpName { get; set; }

       
        public DateTime CreateDate { get; set; }

        //public string CreateUserId { get; set; }
    }
}