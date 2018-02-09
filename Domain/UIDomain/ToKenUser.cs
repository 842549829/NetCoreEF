using System.Collections.Generic;
using Domain.DbDomain;

namespace Domain.UIDomain
{
    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class ToKenUser
    { 
        /// <summary>
        /// 登录
        /// </summary>
        public Result Result { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public IEnumerable<Menu> Menus { get; set; }

        /// <summary>
        /// 员工信息
        /// </summary>
        public Employees Employees { get; set; }
    }
}