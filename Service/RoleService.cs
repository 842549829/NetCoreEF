using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Model;
using Repository;

namespace Service
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns>结果</returns>
        public static void AddRole(Role role)
        {
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                repository.AddEntities(role, true);
            }
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns>结果</returns>
        public static void UpdateRole(Role role)
        {
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                repository.UpdateEntities(role, true);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns>结果</returns>
        public static void RemoveRole(Role role)
        {
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                repository.DeleteEntities(role, true);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        public static Role QueryRolesById(Guid id)
        {
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                return repository.LoadEntitie<Role>(item => item.Id == id);
            }
        }

        /// <summary>
        /// 角色分页查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>结果</returns>
        public static IEnumerable<Role> QueryRolesByPagings(RoleCondition condition)
        {
            using (var roleRepository = Factory.BaseRepositoryFactory())
            {
                var predicate = IEnumerableExtension.GetDynamicExpression<Role, RoleCondition>(condition).Compile();
                var data = roleRepository.LoadPagerEntities(condition.PageSize, condition.PageIndex, out var total, predicate, true, item => item.ModifyTime);
                condition.RowsCount = total;
                return data.ToList();
            }
        }
    }
}