using System;
using Domain.DbDomain;

namespace Domain
{
    /// <summary>
    /// 菜单资源
    /// </summary>
    public class Resource : Menu
    {
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>资源菜单</returns>
        public new Resource Clone()
        {
            return new Resource
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
        /// 地址是否相同
        /// </summary>
        /// <param name="address">菜单地址</param>
        /// <returns>结果</returns>
        internal bool IsSameAddress(string address)
        {
            return string.Compare(this.Url, address, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}