using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Tawjeh.Services;
namespace EmployeeManagement_Tawjeh.Models
{
    public class Employee
    {
        public int Id { get; private set; }

        private static int _nextId = 1;
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        public int DepartId { get; set; }

        public decimal Salary { get; set; }
       public  bool IsActive { get; set; } 

       public  HashSet<string> Skills { get; set; } = new HashSet<string>();




       public  Employee( string name, DateTime hireDate, int departId)
        {
            Id = _nextId++;
            Name = name;
            HireDate = hireDate;

            if (!Company.Departments.ContainsKey(departId))
              throw new Exception($"Can't Assign this Employee ({name}) To a Non Exisiting Department "); 

            DepartId = departId;
                
                IsActive = false;
        }


        
    }
}
