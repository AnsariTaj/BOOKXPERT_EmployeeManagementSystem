using BOOKXPERT_EmployeeManagementSystem.Model;
using BOOKXPERT_EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKXPERT_EmployeeManagementSystem.BusinessLogicLayer.IServices
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(EmployeeModel employee);
        Task UpdateEmployeeAsync(EmployeeModel employee);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<State>> GetStatesAsync();
    }

}
