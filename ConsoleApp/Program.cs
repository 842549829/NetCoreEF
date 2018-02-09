using System;
using Domain;
using Service;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // 初始化数据库结构和表结构
            Factory.EnsureCreated();
           
            // 测试添加员工
            //UserService.AddEmployees(new Employees
            //{
            //    Id = Guid.NewGuid(),
            //    CompanyId = Guid.NewGuid(),
            //    Email = "55553",
            //    Enabled = true,
            //    IsAdministrator = true,
            //    Mobile = "66663",
            //    NickName = "sssx",
            //    Password = "sss",
            //    UserName = "ssss3",
            //    CreateTime = DateTime.Now,
            //    ModifyTime = DateTime.Now

            //});

            // 测试添加
            var id = Guid.NewGuid();
            RoleService.AddRole(new Role
            {
                CompanyId = Guid.NewGuid(),
                CompanyLevel = 1,
                CreateTime = DateTime.Now,
                Describe = "xxx",
                Id = id,
                IsDefaultRole = true,
                ModifyTime = DateTime.Now,
                Name = "的看法"
            });

            // 查询
            var role = RoleService.QueryRolesById(id);

            // 修改
            role.Name = "修改";
            RoleService.UpdateRole(role);

            //删除
            RoleService.RemoveRole(role);

            // 测试分页
            var data = RoleService.QueryRolesByPagings(new Domain.Model.RoleCondition
            {
                Name = "xxxx",
                PageIndex = 1,
                PageSize = 2
            });
        }
    }
}