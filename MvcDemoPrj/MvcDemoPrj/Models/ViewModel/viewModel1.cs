using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemoPrj.Models.ViewModel
{
    public class viewModel1
    {
        //public string a  { get; set; }

        //public IEnumerable<SA_User> temp { get; set; }
        //public IEnumerable<SI_ResearcherVisit> visit { get; set; }
       
        [Required]
        [StringLength(20)]
        [DisplayName("拜訪日期")]
        public string DataDate { get; set; }

        [Required]
        [StringLength(8)]
        [DisplayName("股票代號")]
        public string CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("拜訪公司")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("報告類別")]
        public string ReportType { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("研究員")]
        public string EmpName { get; set; }
        [DisplayName("修改日期")]
        public DateTime CreateDate { get; set; }

        [DisplayName("員工姓名")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
    }
}