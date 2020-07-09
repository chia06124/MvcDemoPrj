namespace MvcDemoPrj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    public partial class SI_ResearcherVisit
    {
        [Key]
        public decimal Seq { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("拜訪日期")]
        public string DataDate { get; set; }

        [Required]
        [StringLength(8)]
        [DisplayName("拜訪公司代號")]
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
        [DisplayName("研究員姓名")]
        public string EmpName { get; set; }

        [DisplayName("建立日期")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("建立者")]
        public string CreateUserId { get; set; }
    }
}
