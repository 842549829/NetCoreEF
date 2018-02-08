using System;

namespace Domain.Model
{
    /// <summary>
    /// 角色查询条件
    /// </summary>
    public class RoleCondition : Paging
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [DynamicExpression(Name = "Name", Operator = "=")]
        public string Name { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [DynamicExpression(Name = "Describe", Operator = "=")]
        public string Describe { get; set; }

        /// <summary>
        /// 是否默认角色
        /// </summary>
        [DynamicExpression(Name = "IsDefaultRole", Operator = "=")]
        public bool? IsDefaultRole { get; set; }

        /// <summary>
        /// 所属公司Id
        /// </summary>
        [DynamicExpression(Name = "CompanyId", Operator = "=")]
        public Guid? CompanyId { get; set; }
    }
}