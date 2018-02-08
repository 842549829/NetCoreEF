using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    /// <summary>
    /// The sql repository.
    /// </summary>
    public class SqlRepository : BaseRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public SqlRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// 生成数据库和表结构
        /// </summary>
        /// <returns>结果</returns>
        public override bool EnsureCreated()
        {
            return this.dbContext.Database.EnsureCreated();
        }

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
        public override void AddEntities<T>(T entity, bool isSubmit = false)
        {
            this.dbContext.Entry(entity).State = EntityState.Added;
            if (isSubmit)
            {
                this.dbContext.SaveChanges();
            }
        }

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
        public override void UpdateEntities<T>(T entity, bool isSubmit = false)
        {
            this.dbContext.Set<T>().Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
            if (isSubmit)
            {
                this.dbContext.SaveChanges();
            }
        }

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
        public override void DeleteEntities<T>(T entity, bool isSubmit = false)
        {
            this.dbContext.Set<T>().Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Deleted;
            if (isSubmit)
            {
                this.dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// LoadEntitie
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="wherelambda">wherelambda</param>
        /// <returns>T</returns>
        public override T LoadEntitie<T>(Func<T, bool> wherelambda)
        {
            return this.dbContext.Set<T>().FirstOrDefault(wherelambda);
        }

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
        public override IQueryable<T> LoadEntities<T>(Func<T, bool> wherelambda)
        {
            return this.dbContext.Set<T>().Where<T>(wherelambda).AsQueryable();
        }

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
        public override IQueryable<T> LoadPagerEntities<TSource, T>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, TSource> orderByLambda)
        {
            total = this.dbContext.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var temp = this.dbContext.Set<T>().Where(whereLambda)
                    .OrderBy(whereLambda)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
                return temp.AsQueryable();
            }
            else
            {
                var temp = this.dbContext.Set<T>().Where(whereLambda)
                    .OrderByDescending(whereLambda)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
                return temp.AsQueryable();
            }
        }
    }
}