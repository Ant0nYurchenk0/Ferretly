using Ferretly.Entities;

namespace Ferretly.Interfaces
{
  public interface IActivitiesRepository
  {
    Task<IEnumerable<Activity>> GetActivityByDateAsync(int employeeId, DateTime date);
    Task<IEnumerable<Activity>> GetActivityByWeekAsync(int employeeId, int week, int year);
    void CreateActivity(Activity activity);
    string FormatActivity(IEnumerable<Activity> activity);
    Task<bool> ActivityExists(int  roleId, int  projectId, int  employeeId, int  typeId);
  }
}
