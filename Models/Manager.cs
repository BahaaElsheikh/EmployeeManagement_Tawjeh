using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Tawjeh.Models
{
  public  class Manager : Employee
    {
        // 
        List<Employee> TeamMembers;

      public  Manager( string name, DateTime hireDate, int departId) : base( name, hireDate, departId)
        {
         
        }

    }
}
