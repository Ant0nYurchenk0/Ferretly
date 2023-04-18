using Ferretly.Entities;

namespace Ferretly.Interfaces
{
  public interface IEmployeesRepository
  {
    Task<IEnumerable<Employee>> GetAlEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);

  }
}
