namespace MvcDemoPrj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    public partial class SI_StocksReport
    {
        [Key]
        public decimal Seq { get; set; }

        [DisplayName("股本")]
        public decimal CapitalStock { get; set; }

        [Required]
        [StringLength(8)]
        [DisplayName("股票代號")]
        public string CompanyId { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("股票名稱")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(1000)]
        [DisplayName("推薦理由")]
        public string Reason { get; set; }
        [DisplayName("收盤價")]
        public decimal ClosePrice { get; set; }
        [DisplayName("目前PER(倍)")]
        public decimal PER { get; set; }
        [DisplayName("目前PBR(倍)")]
        public decimal PBR { get; set; }
        [DisplayName("稅後EPS(元)今年")]
        public decimal EPS_ThisYear { get; set; }
        [DisplayName("稅後EPS(元)明年")]
        public decimal EPS_NextYear { get; set; }
        [DisplayName("目標價")]
        public decimal Targetprice { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("個股報告類別")]
        public string ReportType_BS { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("判斷買進第一筆與賣出結算標記")]
        public string Flag { get; set; }
        [DisplayName("買進價格")]
        public decimal Buy_Price { get; set; }
        [DisplayName("賣出價格")]
        public decimal Sell_Price { get; set; }
        [DisplayName("建立日期")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("建立者")]
        public string CreateUser { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("半年轉標記")]
        public string Next_Flag { get; set; }
    }
}
