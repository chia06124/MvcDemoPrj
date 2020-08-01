namespace MvcDemoPrj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SI_StocksReport
    {
        [Key]
        public decimal Seq { get; set; }

        public decimal CapitalStock { get; set; }

        [Required]
        [StringLength(8)]
        public string CompanyId { get; set; }

        [Required]
        [StringLength(10)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Reason { get; set; }

        public decimal ClosePrice { get; set; }

        public decimal? PER { get; set; }

        public decimal? PBR { get; set; }

        public decimal? EPS_ThisYear { get; set; }

        public decimal? EPS_NextYear { get; set; }

        public decimal Targetprice { get; set; }

        [Required]
        [StringLength(1)]
        public string ReportType_BS { get; set; }

        [Required]
        [StringLength(1)]
        public string Flag { get; set; }

        public decimal Buy_Price { get; set; }

        public decimal Sell_Price { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(5)]
        public string CreateUser { get; set; }

        [Required]
        [StringLength(1)]
        public string Next_Flag { get; set; }
    }
}
