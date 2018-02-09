using Domain;
using Domain.DbDomain;
using Domain.UtilDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    /// <summary>
    /// 当前上下文
    /// </summary>
    public class NotifyEntities : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public NotifyEntities()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options">options</param>
        public NotifyEntities(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// 员工
        /// </summary>
        public DbSet<Employees> Employees { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public DbSet<Company> Company { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<Menu> Menu { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// 用户权限
        /// </summary>
        public DbSet<UserPermissions> UserPermissions { get; set; }

        /// <summary>
        /// 角色权限
        /// </summary>
        public DbSet<RolePermissions> RolePermissions { get; set; }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置员工表字段唯一索引
            modelBuilder.Entity<Employees>().HasIndex(e => e.UserName).IsUnique();
            modelBuilder.Entity<Employees>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<Employees>().HasIndex(e => e.Mobile).IsUnique();

            // 配置公司表字段唯一索引
            modelBuilder.Entity<Company>().HasIndex(c => c.UserName).IsUnique();

            // 设置复合主键
            modelBuilder.Entity<UserPermissions>().HasKey(k => new { k.RoleId, k.UserId });
            modelBuilder.Entity<RolePermissions>().HasKey(k => new { k.RoleId, k.MenuId });
        }

        /// <summary>
        /// 重写配置文件
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = Configuration.GetConfigurationRootByJson("config.json");
            optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
            //optionsBuilder.UseSqlServer("Data Source=(local); Database=NotifyDb; User ID=sa; Password=sqlpass;");
        }
    }
}