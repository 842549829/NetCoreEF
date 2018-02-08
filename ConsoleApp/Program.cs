using System;
using Domain;
using Service;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // 初始化
            UserService.EnsureCreated();

            Employees employees = new Employees
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                Email = "55553",
                Enabled = true,
                IsAdministrator = true,
                Mobile = "66663",
                NickName = "sssx",
                Password ="sss",
                UserName = "ssss3",
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
                
            };
            Company company = new Company {  };

            Service.UserService.AddEmployees(employees);
        }
    }
}
