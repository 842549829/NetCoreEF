using System;

namespace Domain.DbDomain
{
    /// <summary>
    /// 用户角色关系
    /// </summary>
    public class UserPermissions
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }
    }
}