using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferretly.Data
{
  public class RolesRepository : IRolesRepository
  {
    private DataContext _context;

    public RolesRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
      return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
      return await _context.Roles.FindAsync(id);
    }
  }
}
