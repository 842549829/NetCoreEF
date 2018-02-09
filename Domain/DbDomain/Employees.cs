using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbDomain
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employees : EntityBase
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(64)")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(32)]
        [Column(TypeName = "Char(32)")]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(64)")]
        public string NickName { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Required]
        [MaxLength(11)]
        [Column(TypeName = "Char(11)")]
        public string Mobile { get; set; }

        /// <summary>
        /// 启用 禁用
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否是管理员账号
        /// </summary>
        [Required]
        public bool IsAdministrator { get; set; }
    }
}