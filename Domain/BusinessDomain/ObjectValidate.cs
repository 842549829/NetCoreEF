using System;

namespace Domain.BusinessDomain
{
    /// <summary>
    /// 对象验证
    /// </summary>
    public class ObjectValidate
    {
        /// <summary>
        /// 对象空验证
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="describe">描述</param>
        public static void ObjectNullValidate(object obj, string describe)
        {
            if (obj == null)
            {
                throw new Exception(describe);
            }
        }
    }
}