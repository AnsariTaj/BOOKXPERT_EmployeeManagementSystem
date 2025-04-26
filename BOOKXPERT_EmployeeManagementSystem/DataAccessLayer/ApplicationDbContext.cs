using BOOKXPERT_EmployeeManagementSystem.Model;
using BOOKXPERT_EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BOOKXPERT_EmployeeManagementSystem.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<State> States { get; set; }
    }
}
