
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace MvcDemoPrj.SQLModel.Models
{
    

    [Table("sysCodeMap")]
    public partial class sysCodeMap
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Class_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Ch_Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Item_Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Item_Name { get; set; }

        public int? Seq { get; set; }

        [Required]
        [StringLength(10)]
        public string Flag_Usable { get; set; }

        [StringLength(50)]
        public string Memo { get; set; }
    }
}
