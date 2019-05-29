using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_First_API.Models
{
    public class EmployeeModel : PersonModel
    {
        public EmployeeModel(int id, int age, string name, string title)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Title = title;
            this.Roles = new List<string>();
        }
        public string Title;
        public List<string> Roles { get; set; }
    }
}
