using System;
using Domain.DbDomain;
using Repository;

namespace Domain.Service
{
    /// <summary>
    /// 公司服务
    /// </summary>
    public class CompanyService
    {
        /// <summary>
        /// 根据公司Id查询公司
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>公司信息</returns>
        public static Company QueryCompanyById(Guid id)
        {
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                return repository.LoadEntitie<Company>(item => item.Id == id);
            }
        }
    }
}