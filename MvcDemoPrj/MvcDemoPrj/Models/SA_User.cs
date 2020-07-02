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
        [DisplayName("���u�s��")]
        public string UserId { get; set; }

        [DisplayName("Email")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("���u����")]
        public string UserRole { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("���u���")]
        public string UserUnit { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("�K�X")]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("�K�X���")]
        public string PasswordChangeDate { get; set; }
        [DisplayName("�K�X���~�T��")]
        public int PasswordErrorCount { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("���1")]
        public string ExpireDate { get; set; }
        [DisplayName("���2")]
        public DateTime LastLoginDate { get; set; }

        [Required]
        [StringLength(23)]
        [DisplayName("�̫�n�J��m")]
        public string LastLoginHost { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("����")]
        public string UserDesc { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("���u�H�c")]
        public string UserEMail { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("�o����")]
        public string IsCancelled { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("���A")]
        public string PassStatus { get; set; }
        [DisplayName("�إߤ��")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("�إߪ�")]
        public string CreateUserId { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("�ϥΪ�")]
        public string PassUserId { get; set; }
    }
}
