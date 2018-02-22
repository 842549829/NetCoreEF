using System.Collections.Generic;
using System.Linq;
using Domain.DbDomain;
using Repository;

namespace Domain.Service
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService
    {
        /// <summary>
        /// 根据角色查询菜单Id
        /// </summary>
        /// <param name="rolePermissions">角色菜单关系</param>
        /// <returns>菜单</returns>
        public static IEnumerable<Menu> QueryMenuByRoleId(IEnumerable<RolePermissions> rolePermissions)
        {
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                var dbContextMenu = repository.dbContext.Set<Menu>();
                IEnumerable<Menu> menus = (from p in dbContextMenu
                    where (from f in rolePermissions select f.MenuId).Contains(p.Id)
                    select p).ToList();
                return menus;
            }
        }
    }
}