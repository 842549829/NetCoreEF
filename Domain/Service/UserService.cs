using System;
using System.Collections.Generic;
using System.Transactions;
using Domain.DbDomain;
using Domain.UIDomain;
using Repository;

namespace Domain.Service
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

        /// <summary>
        /// 根据用户名查询员工
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>结果</returns>
        public static Employees QueryEmployeesByUserName(string userName)
        {
            using (BaseRepository repository = Factory.BaseRepositoryFactory())
            {
                return repository.LoadEntitie<Employees>(item => item.UserName == userName);
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        /// <returns>登录结果</returns>
        public static ToKenUser Login(LoginInfo loginInfo)
        {
            ToKenUser result = new ToKenUser();
            try
            {
                Employees employees = QueryEmployeesByUserName(loginInfo.UserName);
                UserServiceExtension.EmployeesLoginNullValidate(employees);
                var permissions = employees.Login(loginInfo);
                result.Result = new Result
                {
                    IsSucceed = true
                };
                result.Employees = employees;
                result.Menus = permissions;
            }
            catch (Exception ex)
            {
                result.Result = new Result
                {
                    IsSucceed = false,
                    Message = ex.Message
                };
            }
            return result;
        }
    }
}