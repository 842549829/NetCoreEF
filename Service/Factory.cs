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
    }
}