using System;
using System.Linq.Expressions;
using System.Reflection;
using Domain.UIDomain;

namespace Domain.UtilDomain
{
    /// <summary>
    /// linq扩展
    /// </summary>
    public static class IEnumerableExtension
    {
        /// <summary>
        /// 获取动态表达式
        /// </summary>
        /// <typeparam name="TResult">表达式数据类型</typeparam>
        /// <typeparam name="TCondition">表达式条件类型</typeparam>
        /// <param name="condtion">条件</param>
        /// <returns>表达式</returns>
        public static Expression<Func<TResult, bool>> GetDynamicExpression<TResult, TCondition>(TCondition condtion)
            where TResult : class
            where TCondition : class
        {
            Type tConditionType = typeof(TCondition);
            Type tResultType = typeof(TResult);

            Expression totalExpr = Expression.Constant(true);
            ParameterExpression param = Expression.Parameter(typeof(TResult), "n");
            foreach (PropertyInfo property in tConditionType.GetProperties())
            {
                string key = property.Name;
                object value = property.GetValue(condtion);
                if (value != null && value.ToString() != string.Empty)
                {
                    DynamicExpressionAttribute dynamicExpressionAttribute = CustomAttributeExtension<DynamicExpressionAttribute>.GetCustomAttributeValue(tConditionType, property);
                    if (!dynamicExpressionAttribute.IsOperator)
                    {
                        continue;
                    }

                    //等式左边的值
                    string name = dynamicExpressionAttribute.Name ?? key;
                    Expression left = Expression.Property(param, tResultType.GetProperty(name));
                    //等式右边的值
                    Expression right = Expression.Constant(value);

                    Expression filter;
                    switch (dynamicExpressionAttribute.Operator)
                    {
                        case "!=":
                            filter = Expression.NotEqual(left, right);
                            break;
                        case ">":
                            filter = Expression.GreaterThan(left, right);
                            break;
                        case ">=":
                            filter = Expression.GreaterThanOrEqual(left, right);
                            break;
                        case "<":
                            filter = Expression.LessThan(left, right);
                            break;
                        case "<=":
                            filter = Expression.LessThanOrEqual(left, right);
                            break;
                        case "Contains":
                            filter = Expression.Call(Expression.Property(param, tResultType.GetProperty(name)), typeof(string).GetMethod("Contains", new[] { typeof(string) }), Expression.Constant(value));
                            break;
                        default:
                            filter = Expression.Equal(left, right);
                            break;
                    }
                    totalExpr = Expression.And(filter, totalExpr);
                }
            }
            var predicate = Expression.Lambda(totalExpr, param);
            var dynamic = (Expression<Func<TResult, bool>>)predicate;
            return dynamic;
        }
    }
}