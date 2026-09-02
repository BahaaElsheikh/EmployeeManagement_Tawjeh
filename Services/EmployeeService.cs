using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Tawjeh.Models;
using EmployeeManagement_Tawjeh.Helpers;
namespace EmployeeManagement_Tawjeh.Services
{
    static class EmployeeService
    {
        public static Employee EnterEmployee()
        {
            Console.WriteLine("Enter Employee Name");
            string Name = Console.ReadLine();
            DateTime HireDate = DateTime.Now;
            int DepartId;
            Console.WriteLine("Enter Department ID ");

            while (!int.TryParse(Console.ReadLine(), out DepartId) || !Company.Departments.ContainsKey(DepartId))
            {
                Console.WriteLine("Invalid input Please Enter a Valid Department ID ");
            }

            return new Employee(Name, HireDate, DepartId);
        }

        public static void ShowEmployees(IEnumerable<Employee> employees)
        {
          
            Console.WriteLine(
                $"{"ID",-5} {"Name",-20} {"Salary",-10} {"Hire Date",-15} {"Department",-15} {"Status",-10}");

            Console.WriteLine(new string('-', 80));

            foreach (Employee employee in employees)
            {
                Console.WriteLine(
                    $"{employee.Id,-5} " +
                    $"{employee.Name,-20} " +
                    $"{employee.Salary,-10}" +
                    $"{employee.HireDate.ToString("yyyy-MM-dd"),-15} " +
                    $"{employee.DepartId,-15} " +
                    $"{(employee.IsActive ? "Active" : "Inactive"),-10}");
            }
        }
        

        public static Employee GetEmployeeById(int id , IEnumerable<Employee> employees) {
            foreach (var employee in employees)
            {
                if (employee.Id ==id )
                {
                    return employee;
                }
            }
            return null;
        }
       




        public static Employee SelectEmployee()
        {
            Console.WriteLine($"Select Employee Status:\r\n\r\n" +
                $"1. Active Employee\r\n" +
                $"2. Onboarding Employee\r\n\r\n");

            int c = Validator.ValidInt("enter your choice:\r\n");

            switch (c) {

                case 1:
                    ShowEmployees(Company.ActiveEmployees);
                    int idActive = Validator.ValidInt("Enter Employee ID ");
                    return GetEmployeeById(idActive, Company.ActiveEmployees);
                    
                case 2:
                    ShowEmployees(Company.Onbourding);
                    int idOB = Validator.ValidInt("Enter Employee ID ");
                    return GetEmployeeById(idOB, Company.Onbourding);
                 
                default:
                    return null ;
                    throw new Exception("Invalid Choce Please Chose 1 or 2 Only");
            
            }

        }



        


    }


}
