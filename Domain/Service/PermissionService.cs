using Domain.DbDomain;
using System.Collections.Generic;

namespace Domain.Service
{
    /// <summary>
    /// 权限
    /// </summary>
    public class PermissionService
    {
        /// <summary>
        /// 查询用户的权限
        /// </summary>
        /// <param name="employees">用户</param>
        /// <returns>权限</returns>
        public static PermissionCollection QueryPermission(Employees employees)
        {
            // 加载员工角色
            IEnumerable<UserPermissions> role = RoleService.QueryUserPermissionsByUserId(employees.Id);
            if (role == null)
            {
                // 加载公司角色
                role = RoleService.QueryUserPermissionsByUserId(employees.Company.Id);
            }

            if (role != null)
            {
                // 加载用户菜单
                var rolePermissions = RoleService.QueryRolePermissionsByRoleId(role);
                var menu = MenuService.QueryMenuByRoleId(rolePermissions);
                PermissionCollection permissionCollection = new PermissionCollection(menu);
                return permissionCollection;
            }

            return null;
        }

    }
}