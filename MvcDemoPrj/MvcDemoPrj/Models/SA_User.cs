namespace MvcDemoPrj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_User
    {
        [Key]
        [StringLength(20)]
        [DisplayName("員工編號")]
        public string UserId { get; set; }

        [DisplayName("Email")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("員工角色")]
        public string UserRole { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("員工單位")]
        public string UserUnit { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("密碼")]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("密碼日期")]
        public string PasswordChangeDate { get; set; }
        [DisplayName("密碼錯誤訊息")]
        public int PasswordErrorCount { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("日期1")]
        public string ExpireDate { get; set; }
        [DisplayName("日期2")]
        public DateTime LastLoginDate { get; set; }

        [Required]
        [StringLength(23)]
        [DisplayName("最後登入位置")]
        public string LastLoginHost { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("順序")]
        public string UserDesc { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("員工信箱")]
        public string UserEMail { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("這什麼")]
        public string IsCancelled { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("狀態")]
        public string PassStatus { get; set; }
        [DisplayName("建立日期")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("建立者")]
        public string CreateUserId { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("使用者")]
        public string PassUserId { get; set; }
    }
}
