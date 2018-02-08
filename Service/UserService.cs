using System.Transactions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Service
{
    /// <summary>
    /// 权限测试
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employees">员工</param>
        public static void AddEmployees(Employees employees)
        {
            using (BaseRepository repository = Factory())
            {
                repository.AddEntities(employees, true);
            }
        }

        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="company">公司信息</param>
        /// <param name="employees">员工信息</param>
        public static void AddCompany(Company company, Employees employees)
        {
            using (BaseRepository repository = Factory())
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    repository.AddEntities(company);
                    repository.AddEntities(employees);
                    trans.Complete();
                }
            }
        }

        /// <summary>
        /// 工厂方法
        /// </summary>
        /// <returns>数据仓储</returns>
        public static BaseRepository Factory()
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
            using (BaseRepository repository = Factory())
            {
                return repository.EnsureCreated();
            }
        }
    }
}