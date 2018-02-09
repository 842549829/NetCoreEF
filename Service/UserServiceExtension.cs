using Domain.DbDomain;
using Domain.LogicDomain;

namespace Service
{
    /// <summary>
    /// 用户服务扩展
    /// </summary>
    public class UserServiceExtension
    {
        /// <summary>
        /// 验证员工对象
        /// </summary>
        /// <param name="employees">员工对象</param>
        public static void EmployeesLoginNullValidate(Employees employees)
        {
            ObjectValidate.ObjectNullValidate(employees, "登录帐号不存在");
        }
    }
}