using My_First_API.Controllers;
using My_First_API.Data;
using My_First_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Firt_API.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<EmployeeModel> GetAll()
        {
            return Database.Employees;
        }

        public bool Exists(string name, int age, string title)
        {
            return GetAll().Any(i => i.Name == name && i.Age == age && i.Title == title);
        }

        public EmployeeModel Create(string name, int age, string title)
        {
            var employee = new EmployeeModel(NextEmployeeId(), age, name, title);
            Database.Employees.ToList().Add(employee);
            return employee;
        }

        public EmployeeModel Get(int id)
        {
            return GetAll().FirstOrDefault(i => i.Id == id);
        }

        public int NextEmployeeId()
        {
            return GetAll().Max(i => i.Id) + 1;
        }

        public bool Delete(int id)
        {
            return GetAll().ToList().RemoveAll(i => i.Id == id) != 0;
        }
    }

    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> GetAll();
        bool Exists(string name, int age, string title);
        EmployeeModel Get(int id);
        EmployeeModel Create(string name, int age, string title);
        bool Delete(int id);
        int NextEmployeeId();
    }
}
