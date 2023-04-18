using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferretly.Data
{
  public class EmployeesRepository : IEmployeesRepository
  {
    private DataContext _context;

    public EmployeesRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<IEnumerable<Employee>> GetAlEmployeesAsync()
    {
      return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
      return await _context.Employees.FindAsync(id);

    }
  }
}
