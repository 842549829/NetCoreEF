using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.UIDomain;
using Domain.UtilDomain;

namespace Domain.DbDomain
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employees : EntityBase
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(64)")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(32)]
        [Column(TypeName = "Char(32)")]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        [Column(TypeName = "Varchar(64)")]
        public string NickName { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Required]
        [MaxLength(11)]
        [Column(TypeName = "Char(11)")]
        public string Mobile { get; set; }

        /// <summary>
        /// 启用 禁用
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否是管理员账号
        /// </summary>
        [Required]
        public bool IsAdministrator { get; set; }

        /// <summary>
        /// 公司信息
        /// </summary>
        [NotMapped]
        public Company Company  { get; set; }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        public IEnumerable<Menu> Login(LoginInfo loginInfo)
        {
            this.ValidateLogin(loginInfo.LoginPassword);

            return null;
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="password">登录密码</param>
        public void ValidateLogin(string password)
        {
            if (this.Id == Guid.Empty)
            {
                throw new Exception("帐号不存在");
            }
            if (this.Password != Md5.Encrypt32(password))
            {
                throw new Exception("帐号登录密码错误");
            }
        }

        /// <summary>
        /// 登录密码加密
        /// </summary>
        public void EncryptPassword()
        {
            this.Password = Md5.Encrypt32(this.Password);
        }
    }
}