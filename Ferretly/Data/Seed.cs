using Ferretly.Entities;
using System.Text.Json;

namespace Ferretly.Data
{
  public class Seed
  {
    public static async Task SeedRoles(DataContext context)
    {
      if (context.Roles.Any()) return;
      var data = await File.ReadAllTextAsync("Data/SeedData/Roles.json");
      var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
      var roles = JsonSerializer.Deserialize<List<Role>>(data);
      await context.Roles.AddRangeAsync(roles);
      await context.SaveChangesAsync();
    }
    public static async Task SeedActivityTypes(DataContext context)
    {
      if (context.ActivityTypes.Any()) return;
      var data = await File.ReadAllTextAsync("Data/SeedData/ActivityTypes.json");
      var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
      var types = JsonSerializer.Deserialize<List<ActivityType>>(data);
      await context.ActivityTypes.AddRangeAsync(types);
      await context.SaveChangesAsync();
    }
    public static async Task SeedEmployees(DataContext context)
    {
      if (context.Employees.Any()) return;
      var data = await File.ReadAllTextAsync("Data/SeedData/Employees.json");
      var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
      var employees = JsonSerializer.Deserialize<List<Employee>>(data);
      await context.Employees.AddRangeAsync(employees);
      await context.SaveChangesAsync();
    }
  }
}
