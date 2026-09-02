using EmployeeManagement_Tawjeh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Tawjeh.Services
{
    public static class DepartmentService
    {
        public static List<Employee> GetEmployeesByDepartmentID(int id)
        {
            List<Employee> Result = new List<Employee>();

            foreach (var item in Company.ActiveEmployees)
            {
                if (item.DepartId == id)
                {
                    Result.Add(item);
                }
            }
            foreach (var item in Company.Onbourding)
            {
                if (item.DepartId == id)
                {
                    Result.Add(item);
                }
            }

            return Result;
        }
    }
}
