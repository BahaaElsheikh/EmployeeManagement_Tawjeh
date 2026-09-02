using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Tawjeh.Models
{
 public class Department
    {
        public int Id { get; set; }
        public string DepartName { get; set; }

       public  Department(int id , string name) { 
             Id = id;
            DepartName = name;
        }
    }
}
