using System;

namespace Domain.DbDomain
{
    /// <summary>
    /// 角色菜单关系
    /// </summary>
    public class RolePermissions
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public Guid MenuId { get; set; }
    }
}