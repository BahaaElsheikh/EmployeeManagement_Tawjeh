using EmployeeManagement_Tawjeh.Data; 
using EmployeeManagement_Tawjeh.Services;
using EmployeeManagement_Tawjeh.Helpers;
using EmployeeManagement_Tawjeh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeManagement_Tawjeh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeedData.AddAllSeedData();
            //Company.TestCompany();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("       Employee Management System");
                Console.WriteLine("==========================================");

                Console.WriteLine("1. Add Employee to Onboarding");
                Console.WriteLine("2. Process First Employee");
                Console.WriteLine("3. Add Department");
                Console.WriteLine("4. Add Skill to Employee");
                Console.WriteLine("5. Search for Employee");
                Console.WriteLine("6. Show Department Employees");
                Console.WriteLine("7. Calculate Average Salary");
                Console.WriteLine("8. Department Report");
                Console.WriteLine("9. Show Unique Skills");
                Console.WriteLine("10. Show Active Employees");
                Console.WriteLine("11. Show Onboarding Employees");
                Console.WriteLine("12. Show Actions History");
                Console.WriteLine("0. Exit");

                Console.WriteLine("==========================================");

                int choice = Validator.ValidInt("Enter your choice: ");

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Company.AddEmployeeToOnbourding();
                            break;

                        case 2:
                            decimal salary = Validator.ValidInt(
                                "Enter Employee Salary: ");

                            Company.ProcessTheFirstEmployee(salary);
                            break;

                        case 3:
                            Company.AddDepartment();
                            break;

                        case 4:
                            Company.AddSkillToEmployee();
                            break;

                        case 5:
                            Company.SearchForEmployee();
                            break;

                        case 6:
                            Company.ShowDepartmentEmployees();
                            break;

                        case 7:
                            Company.CalculateAvgSalary(Company.ActiveEmployees);
                            break;

                        case 8:
                            Company.DepartmentReport();
                            break;

                        case 9:
                            Company.ShowUniqueSkills();
                            break;

                        case 10:
                            EmployeeService.ShowEmployees(Company.ActiveEmployees);
                            break;

                        case 11:
                            EmployeeService.ShowEmployees(Company.Onbourding);
                            break;

                        case 12:
                           Company.ShowActionsHistory();
                            break;

                        case 0:
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            Console.WriteLine(
                                "Invalid Choice! Please choose from 0 to 11.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }


        }
    }
}
