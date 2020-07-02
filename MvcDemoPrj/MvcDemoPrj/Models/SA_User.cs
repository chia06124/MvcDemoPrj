namespace MvcDemoPrj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_User
    {
        [Key]
        [StringLength(20)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserRole { get; set; }

        [Required]
        [StringLength(20)]
        public string UserUnit { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string PasswordChangeDate { get; set; }

        public int PasswordErrorCount { get; set; }

        [Required]
        [StringLength(10)]
        public string ExpireDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        [Required]
        [StringLength(23)]
        public string LastLoginHost { get; set; }

        [Required]
        [StringLength(100)]
        public string UserDesc { get; set; }

        [Required]
        [StringLength(100)]
        public string UserEMail { get; set; }

        [Required]
        [StringLength(1)]
        public string IsCancelled { get; set; }

        [Required]
        [StringLength(1)]
        public string PassStatus { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(20)]
        public string CreateUserId { get; set; }

        [Required]
        [StringLength(20)]
        public string PassUserId { get; set; }
    }
}
