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

        [DisplayName("�ѥ�")]
        public decimal CapitalStock { get; set; }

        [Required]
        [StringLength(8)]
        [DisplayName("�Ѳ��N��")]
        public string CompanyId { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("�Ѳ��W��")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(1000)]
        [DisplayName("���˲z��")]
        public string Reason { get; set; }
        [DisplayName("���L��")]
        public decimal ClosePrice { get; set; }
        [DisplayName("�ثePER(��)")]
        public decimal PER { get; set; }
        [DisplayName("�ثePBR(��)")]
        public decimal PBR { get; set; }
        [DisplayName("�|��EPS(��)���~")]
        public decimal EPS_ThisYear { get; set; }
        [DisplayName("�|��EPS(��)���~")]
        public decimal EPS_NextYear { get; set; }
        [DisplayName("�ؼл�")]
        public decimal Targetprice { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("�Ӫѳ��i���O")]
        public string ReportType_BS { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("�P�_�R�i�Ĥ@���P��X����аO")]
        public string Flag { get; set; }
        [DisplayName("�R�i����")]
        public decimal Buy_Price { get; set; }
        [DisplayName("��X����")]
        public decimal Sell_Price { get; set; }
        [DisplayName("�إߤ��")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("�إߪ�")]
        public string CreateUser { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("�b�~��аO")]
        public string Next_Flag { get; set; }
    }
}
