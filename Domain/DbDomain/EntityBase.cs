using System;

namespace Domain.DbDomain
{
    /// <summary>
    /// 基础类
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 生成Guid
        /// </summary>
        /// <returns>生成Guid</returns>
        public Guid GetGuid()
        {
            lock (this)
            {
                return Guid.NewGuid();
            }
        }
    }
}