using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DbDomain
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 上级部门Id
        /// </summary>
        public Guid ParntId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        [MaxLength(256)]
        public string Describe { get; set; }
    }
}