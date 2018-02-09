using System.Transactions;
using Domain;
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
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
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
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    repository.AddEntities(company);
                    repository.AddEntities(employees);
                    trans.Complete();
                }
            }
        }
    }
}