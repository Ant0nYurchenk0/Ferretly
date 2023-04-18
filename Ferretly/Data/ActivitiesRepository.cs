using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace Ferretly.Data
{
  public class ActivitiesRepository : IActivitiesRepository
  {
    private DataContext _context;

    public ActivitiesRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<bool> ActivityExists(int  roleId, int projectId, int  employeeId, int typeId)
    {
      if (await _context.Activities.AnyAsync(a => a.RoleId == roleId
                                                && a.ProjectId == projectId
                                                && a.TypeId == typeId
                                                && a.EmployeeId == employeeId))
        return true;
      return false;
    }

    public void CreateActivity(Activity activity)
    {
      _context.Activities.Add(activity);
    }

    public string FormatActivity(IEnumerable<Activity> activites)
    {
      var result = new StringBuilder();
      foreach (var activity in activites)
      {
        result.Append(DateOnly.FromDateTime(activity.Date).ToString());
        result.Append(" as a ");
        result.Append(activity.Role.Name);
        result.Append(" ");
        result.Append(activity.Employee.Name);
        result.Append(" worked on the project ");
        result.Append(activity.Project.Name);
        result.Append(" ");
        result.Append(activity.NumOfHours);
        result.Append(" hours ");
        result.Append(activity.Type.Name);
        result.Append("; ");
        result.AppendLine();
      }
      return result.ToString();
    }

    public async Task<IEnumerable<Activity>> GetActivityByDateAsync(int employeeId, DateTime date)
    {
      return await _context.Activities
        .Where(a => a.EmployeeId == employeeId && a.Date.Date == date.Date)
        .Include(a=>a.Role)
        .Include(a=>a.Project)
        .Include(a=>a.Type)
        .Include(a=>a.Employee)
        .ToListAsync();
    }

    public async Task<IEnumerable<Activity>> GetActivityByWeekAsync(int employeeId, int week, int year)
    {

      var startDate = GetStartDayOfWeek(week, year);
      var endDate = startDate.AddDays(7);
      return await _context.Activities
        .Where(a => a.EmployeeId == employeeId 
                    && a.Date.Date >= startDate.Date
                    && a.Date.Date <= endDate.Date)
        .Include(a => a.Role)
        .Include(a => a.Project)
        .Include(a => a.Type)
        .Include(a => a.Employee)
        .ToListAsync();
    }
    private DateTime GetStartDayOfWeek(int week, int year)
    {
      DateTime jan1 = new DateTime(year, 1, 1);
      int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
      DateTime firstThursday = jan1.AddDays(daysOffset);
      var cal = CultureInfo.CurrentCulture.Calendar;
      int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
      var weekNum = week;
      if (firstWeek == 1)
      {
        weekNum -= 1;
      }
      var result = firstThursday.AddDays(weekNum * 7);
      return result.AddDays(-3);
    }
  }
}
