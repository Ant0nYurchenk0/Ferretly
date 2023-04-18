using Ferretly.Entities;

namespace Ferretly.Interfaces
{
  public interface IRolesRepository
  {
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int id);

  }
}
