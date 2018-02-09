using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbDomain
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(20)")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(64)")]
        public string Describe { get; set; }
        
        /// <summary>
        /// 是否默认角色
        /// </summary>
        public bool IsDefaultRole { get; set; }

        /// <summary>
        /// 所属公司Id
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// 公司级别
        /// </summary>
        public int CompanyLevel { get; set; }

        /// <summary>
        /// 角色类型 {0:公司角色 ,1:员工角色}
        /// </summary>
        public int RoleType { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        private readonly List<Menu> m_menus = new List<Menu>();

        /// <summary>
        /// 可访问菜单集合
        /// </summary>
        [NotMapped]
        public IEnumerable<Menu> Menus => m_menus.AsReadOnly();

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="item">菜单</param>
        internal void AppendMenu(Menu item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (this.m_menus.Exists(menu => menu.Id == item.Id))
            {
                throw new Exception("不能重复添加的同一菜单");
            }
            this.m_menus.Add(item);
        }
    }
}