using EmployeeManagement_Tawjeh.Helpers;
using EmployeeManagement_Tawjeh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Tawjeh.Services
{
    public static class Company
    {
        public static List<Employee> ActiveEmployees = new List<Employee>();
        public static Dictionary<int, Department> Departments = new Dictionary<int, Department>();
        public static Queue<Employee> Onbourding = new Queue<Employee>();
        public static Stack<ActionHistory> ActionsHistory = new Stack<ActionHistory>();
        public static HashSet<string> Skills = new HashSet<string>();


        public static void TestCompany()
        {
            // AddEmployeeToOnbourding();
            // PrrocessTheFirstEmployee(2000);
            //AddDepartment();
            //AddSkillToEmployee;
            //SearchForEmployee();
            //ShowDepartmentEmployees();

        }

        public static void AddEmployeeToOnbourding()
        {
            var Employee = EmployeeService.EnterEmployee();
            Onbourding.Enqueue(Employee);

            ActionsHistory.Push(new ActionHistory($"New Employee {Employee.Name} Added To Onbourding Queue")); 
        }

        public static void ProcessTheFirstEmployee(decimal salary)
        {
            var Employee = Onbourding.Dequeue();
            Employee.IsActive = true;
            Employee.Salary = salary;
            ActiveEmployees.Add(Employee);

            ActionsHistory.Push(new ActionHistory($"Employee {Employee.Name} Has Been Activated With Salary = {salary}"));

        }

        public static void AddDepartment()
        {
            Console.WriteLine("Enter Department ID");
            int id;
            while (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Invalid input Please Enter a Valid Department ID ");
            }


            Console.WriteLine("Enter Department Name");
            string Name = Console.ReadLine();

            Departments[id] = new Department(id, Name);

            ActionsHistory.Push(new ActionHistory($"New Department{Name} Added "));

        }

        public static void AddSkillToEmployee()
        {
            var Employee = EmployeeService.SelectEmployee();
            if (Employee is null)
            {
                throw new Exception("Employee Not Exist ");
            }

            Console.WriteLine("Enter A Skill ");
            string Skill = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(Skill))
            {
                throw new Exception("Skill name is required.");
            }



            Employee.Skills.Add(Skill);
            Skills.Add(Skill);

            ActionsHistory.Push(new ActionHistory($"New Skill : {Skill} Added To HashSet"));

        }


        public static void SearchForEmployee() {
            Console.WriteLine("Search By Name or Id");
            string  query = Console.ReadLine();
            List<Employee> Result= new List<Employee>();

            if (int.TryParse(query,out int id)) // id 
            {
               Result = ActiveEmployees.FindAll(e=>e.Id  == id); 
            }
            else // Name
            {
                Result = ActiveEmployees.FindAll(e => e.Name==query);
            }

            EmployeeService.ShowEmployees(Result);
        }

        public static void ShowDepartmentEmployees()
        {

            foreach (var item in Departments)
            {
                Console.WriteLine($"{item.Key} : {item.Value.DepartName}");
            }

            int id = Validator.ValidInt("Enter Department ID");

            if (!Company.Departments.ContainsKey(id))
            {
                throw new Exception("This Department Doesn't Exist");
            }

            List<Employee> Result= DepartmentService.GetEmployeesByDepartmentID(id);


            EmployeeService.ShowEmployees(Result);

        }

        public static void CalculateAvgSalary(List<Employee> employees)
        {
           
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("Average Salary is 0 (No employees found)");
                return;
            }

            decimal sum = 0;
            foreach (Employee emp in employees)
            {
                sum += emp.Salary;
            }

            decimal avg = sum / employees.Count;

            Console.WriteLine($"Average Salary is {avg:C}"); 
        }


        public static void DepartmentReport()
        {
            foreach (var item in Departments)
            {
               var Employees =  DepartmentService.GetEmployeesByDepartmentID(item.Value.Id);

                EmployeeService.ShowEmployees(Employees);
                Console.WriteLine($"{"========================================",-20}");
                CalculateAvgSalary(Employees);
            }

        }


        public static void ShowUniqueSkills()
        {
            Console.WriteLine("========== Unique Skills ===============");
            foreach (var item in Skills)
            {
                Console.WriteLine(item);
            }

        }


        public static void ShowActionsHistory()
        {
            foreach (var item in ActionsHistory)
            {
                Console.WriteLine(item.MSG);
            }
        }


    }


}
