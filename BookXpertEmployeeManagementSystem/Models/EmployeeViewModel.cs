using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookXpertEmployeeManagementSystem.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<Data> Employees { get; set; }
        public IEnumerable<States> States { get; set; }
       
    }
}
