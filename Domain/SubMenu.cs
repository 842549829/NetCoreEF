using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    /// <summary>
    /// 菜单子集
    /// </summary>
    public class SubMenu : Menu
    {
        /// <summary>
        /// 菜单资源集合
        /// </summary>
        public readonly List<Resource> m_resources;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SubMenu()
        {
            this.m_resources = new List<Resource>();
        }

        /// <summary>
        /// 菜单资源集合
        /// </summary>
        public IEnumerable<Resource> Resources => m_resources.AsReadOnly();

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>子菜单</returns>
        public new SubMenu Clone()
        {
            var result = new SubMenu
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
            foreach (var item in m_resources)
            {
                result.AppendResource(item.Clone());
            }
            return result;
        }

        /// <summary>
        /// 添加资源菜单
        /// </summary>
        /// <param name="item">资源菜单</param>
        internal void AppendResource(Resource item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            //如果有同一资源菜单就不进行添加了
            if (this.m_resources.Any(menu => menu.Id == item.Id))
            {
                return;
            }
            this.m_resources.Add(item);
        }

        /// <summary>
        /// 是否包含菜单
        /// </summary>
        /// <param name="address">菜单地址</param>
        /// <returns>结果</returns>
        internal bool ContainValidResource(string address)
        {
            return string.Compare(this.Url, address, StringComparison.OrdinalIgnoreCase) == 0 || m_resources.Any(item => item.IsSameAddress(address));
        }
    }
}