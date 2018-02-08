using Domain;
using Repository;

namespace Service
{
    class RoleService
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
    }
}