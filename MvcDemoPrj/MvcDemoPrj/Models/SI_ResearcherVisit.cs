namespace MvcDemoPrj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SI_ResearcherVisit
    {
        [Key]
        public decimal Seq { get; set; }

        [Required]
        [StringLength(20)]
        public string DataDate { get; set; }

        [Required]
        [StringLength(8)]
        public string CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(1)]
        public string ReportType { get; set; }

        [Required]
        [StringLength(20)]
        public string EmpName { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(5)]
        public string CreateUserId { get; set; }
    }
}
