using Ferretly.Entities;

namespace Ferretly.Interfaces
{
  public interface IActivityTypesRepository
  {
    Task<IEnumerable<ActivityType>> GetAllActivityTypesAsync();
    Task<ActivityType> GetActivityTypeByIdAsync(int id);
  }
}
