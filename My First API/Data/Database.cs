using My_First_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_First_API.Data
{
    public static class Database
    {
        public static IEnumerable<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel(1, 27, "Jonathan Moore", "Developer"),
            new EmployeeModel(2, 26, "Robert Moore", "CA"),
            new EmployeeModel(3, 51, "Debbie Moore", "Chiropractor")
        };
    }
}
