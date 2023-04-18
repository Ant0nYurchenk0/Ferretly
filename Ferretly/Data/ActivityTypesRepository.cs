using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferretly.Data
{
  public class ActivityTypesRepository : IActivityTypesRepository
  {
    private DataContext _context;

    public ActivityTypesRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<ActivityType> GetActivityTypeByIdAsync(int id)
    {
      return await _context.ActivityTypes.FindAsync(id);
    }

    public async Task<IEnumerable<ActivityType>> GetAllActivityTypesAsync()
    {
      return await _context.ActivityTypes.ToListAsync();
    }
  }
}
