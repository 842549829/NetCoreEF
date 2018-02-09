using Data;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Service
{
    /// <summary>
    /// 工厂
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// 工厂方法
        /// </summary>
        /// <returns>数据仓储</returns>
        public static BaseRepository BaseRepositoryFactory()
        {
            DbContext dbContext = new NotifyEntities();
            BaseRepository repository = new SqlRepository(dbContext);
            return repository;
        }

        /// <summary>
        /// 生成数据库和表结构
        /// </summary>
        /// <returns>结果</returns>
        public static bool EnsureCreated()
        {
            using (BaseRepository repository = BaseRepositoryFactory())
            {
                return repository.EnsureCreated();
            }
        }
    }
}