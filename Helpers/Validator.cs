using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Tawjeh.Helpers
{
    public static class Validator
    {

        public static int ValidInt(string msg)
        {
            Console.WriteLine(msg);
            int n;
            while (!int.TryParse(Console.ReadLine(),out n))
            {
                Console.WriteLine($"Invalid int Please {msg}");
            }
            return n;
        }



    }
}
