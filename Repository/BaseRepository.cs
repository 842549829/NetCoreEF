using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    /// <summary>
    /// BaseRepository
    /// </summary>
    public abstract class BaseRepository : IDisposable
    {
        /// <summary>
        /// The db context.
        /// </summary>
        protected readonly DbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="bdContext">
        /// The db context.
        /// </param>
        protected BaseRepository(DbContext bdContext)
        {
            this.dbContext = bdContext;
        }

        /// <summary>
        /// 生成数据库和表结构
        /// </summary>
        /// <returns>结果</returns>
        public abstract bool EnsureCreated();

        /// <summary>
        /// The add entities.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="isSubmit">
        /// The is submit.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public abstract void AddEntities<T>(T entity, bool isSubmit = false) where T : class;

        /// <summary>
        /// The update entities.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="isSubmit">
        /// The is submit.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public abstract void UpdateEntities<T>(T entity, bool isSubmit = false) where T : class;

        /// <summary>
        /// The delete entities.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="isSubmit">
        /// The is submit.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public abstract void DeleteEntities<T>(T entity, bool isSubmit = false) where T : class;

        /// <summary>
        /// LoadEntitie
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="wherelambda">wherelambda</param>
        /// <returns>T</returns>
        public abstract T LoadEntitie<T>(Func<T, bool> wherelambda) where T : class;

        /// <summary>
        /// The load entities m.
        /// </summary>
        /// <param name="wherelambda">
        /// The wherelambda.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public abstract IQueryable<T> LoadEntities<T>(Func<T, bool> wherelambda) where T : class;

        /// <summary>
        /// The load pager entities.
        /// </summary>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="total">
        /// The total.
        /// </param>
        /// <param name="whereLambda">
        /// The where lambda.
        /// </param>
        /// <param name="isAsc">
        /// The is asc.
        /// </param>
        /// <param name="orderByLambda">
        /// The order by lambda.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public abstract IQueryable<T> LoadPagerEntities<TSource, T>(
            int pageSize,
            int pageIndex,
            out int total,
            Func<T, bool> whereLambda,
            bool isAsc,
            Func<T, TSource> orderByLambda) where T : class;

        //public virtual void Log()
        //{
        //    this.dbContext.Database.Log = (sql) =>
        //    {
        //        if (string.IsNullOrEmpty(sql) == false)
        //        {
        //            Console.WriteLine("************sql执行*************");
        //            Console.WriteLine(sql);
        //            Console.WriteLine("************sql结束************");
        //        }
        //    };
        //}

        /// <summary>
        /// 释放资源
        /// </summary>
        public virtual void Dispose()
        {
            this.dbContext?.Dispose();
        }
    }
}