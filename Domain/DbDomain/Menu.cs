﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.DbDomain
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu : EntityBase
    {
        /// <summary>
        /// 菜单子集
        /// </summary>
        public List<SubMenu> m_children = new List<SubMenu>();

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 父级菜单
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(16)")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(64)")]
        public string Describe { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(255)")]
        public string Url { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(255)")]
        public string Icon { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int MenuType { get; set; }

        /// <summary>
        /// 子菜单集合
        /// </summary>
        [NotMapped]
        public IEnumerable<SubMenu> Children => this.m_children.AsReadOnly();

        /// <summary>
        /// 是否空菜单
        /// </summary>
        [NotMapped]
        public bool IsEmpty => !this.m_children.Any();

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>菜单</returns>
        public Menu Clone()
        {
            var result = CloneMain();
            this.m_children.ForEach(item => result.AppendChild(item.Clone()));
            return result;
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>菜单</returns>
        private Menu CloneMain()
        {
            return new Menu
            {
                Id = this.Id,
                Name = this.Name,
                Url = this.Url,
                ParentId = this.ParentId,
                Sort = this.Sort,
                Describe = this.Describe,
                Icon = this.Icon,
                CompanyId = this.CompanyId,
                CreateTime = this.CreateTime,
                MenuType = this.MenuType,
                ModifyTime = this.ModifyTime
            };
        }

        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="item">子菜单</param>
        internal void AppendChild(SubMenu item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (this.m_children.Any(menu => menu.Id == item.Id))
            {
                throw new Exception("不能重复添加的同一子菜单");
            }
            this.m_children.Add(item);
        }

        /// <summary>
        /// 是否包含子菜单
        /// </summary>
        /// <param name="child">子菜单Id</param>
        /// <returns>结果</returns>
        internal bool ContainsChild(Guid child)
        {
            return this.m_children.Exists(item => item.Id == child);
        }

        /// <summary>
        /// 是否包含资源菜单
        /// </summary>
        /// <param name="address">菜单地址</param>
        /// <returns>结果</returns>
        internal bool ContainsResource(string address)
        {
            return this.m_children.Any(item => item.ContainValidResource(address));
        }

        /// <summary>
        /// 排序
        /// </summary>
        internal void Sorting()
        {
            if (this.m_children.Count > 1)
            {
                this.m_children = this.m_children.OrderBy(subMenu => subMenu.Sort).ToList();
            }
        }

        /// <summary>
        /// 组合菜单
        /// </summary>
        /// <param name="first">菜单1</param>
        /// <param name="second">菜单2</param>
        /// <returns>菜单</returns>
        internal static Menu Union(Menu first, Menu second)
        {
            Menu result = null;
            if (first == null)
            {
                if (second != null)
                {
                    result = second.Clone();
                }
            }
            else
            {
                result = first.Clone();
                if (second == null)
                {
                    return result;
                }
                foreach (var item in second.Children.Where(item => !result.ContainsChild(item.Id)))
                {
                    result.AppendChild(item);
                }
            }
            return result;
        }

        /// <summary>
        /// 菜单交叉
        /// </summary>
        /// <param name="first">菜单1</param>
        /// <param name="second">菜单2</param>
        /// <returns>菜单</returns>
        internal static Menu Intersact(Menu first, Menu second)
        {
            if (first == null || second == null || first.IsEmpty || second.IsEmpty)
            {
                return null;
            }
            var result = first.CloneMain();
            foreach (var item in first.Children.Where(item => second.ContainsChild(item.Id)))
            {
                result.AppendChild(item.Clone());
            }
            return result;
        }

        /// <summary>
        /// 菜单减去
        /// </summary>
        /// <param name="first">菜单1</param>
        /// <param name="second">菜单2</param>
        /// <returns>菜单</returns>
        internal static Menu Subtract(Menu first, Menu second)
        {
            if (first == null)
            {
                return null;
            }
            if (second == null)
            {
                return first.Clone();
            }
            var result = first.CloneMain();
            foreach (var item in first.Children.Where(item => !second.ContainsChild(item.Id)))
            {
                result.AppendChild(item.Clone());
            }
            return result;
        }
    }
}