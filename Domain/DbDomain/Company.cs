using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbDomain
{
    /// <summary>
    /// 公司
    /// </summary>
    public class Company : EntityBase
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 上级公司Id
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 公司帐号
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(255)")]
        public string UserName { get; set; }

        /// <summary>
        /// 公司名字
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(150)")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(200)")]
        public string Address { get; set; }

        /// <summary>
        /// 公司级别
        /// </summary>
        public int Level { get; set; }
    }
}