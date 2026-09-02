using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Tawjeh.Helpers
{
    public class ActionHistory
    {
       public string MSG= string.Empty;

        public ActionHistory(string msg) {
            MSG = $"{msg} - {DateTime.Now}"; 
        }

        
    }
}
