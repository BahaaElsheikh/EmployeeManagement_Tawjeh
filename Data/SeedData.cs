using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeManagement_Tawjeh.Services;
using EmployeeManagement_Tawjeh.Models;

namespace EmployeeManagement_Tawjeh.Data
{
    public static class SeedData
    {
        public static void AddSeedDeparts()
        {
            Company.Departments.Add(1, new Department(1, "Hr"));
            Company.Departments.Add(2, new Department(2, "Pr"));
            Company.Departments.Add(3, new Department(3, "Media"));
            Company.Departments.Add(4, new Department(4, "Engineering"));
            Company.Departments.Add(5, new Department(5, "QA"));
            Company.Departments.Add(6, new Department(6, "finance"));
        }



        public static void AddSeedEmployeesToOnbourding()
        {
            Company.ActiveEmployees.Add(new Employee("Ahmed" ,DateTime.Now ,2 ));
            Company.ActiveEmployees.Add(new Employee("Sayed" ,DateTime.Now ,4 ));
            Company.ActiveEmployees.Add(new Employee("Wael" ,DateTime.Now ,6 ));
            Company.ActiveEmployees.Add(new Employee("Omar" ,DateTime.Now ,3 ));
            Company.ActiveEmployees.Add(new Employee("Khaled" ,DateTime.Now ,5 ));
            Company.ActiveEmployees.Add(new Employee("Mina" ,DateTime.Now ,1 ));
            Company.ActiveEmployees.Add(new Employee("Fady" ,DateTime.Now ,3 ));
        }

        public static void ProcessAllEmployee() /// Set Random Salaries For OnBourding
        {
            decimal min = 5000;
            decimal max = 20000;

            for (int i = 0; i < Company.Onbourding.Count; i++)
            {
                Random random = new Random();
               decimal salary =  (decimal)random.NextDouble() * (max - min) + min;

                Company.ProcessTheFirstEmployee(salary);
            }
        }


        public static void AddAllSeedData()
        {
            AddSeedDeparts();
            AddSeedEmployeesToOnbourding();
            ProcessAllEmployee();
        } 
    }
}
