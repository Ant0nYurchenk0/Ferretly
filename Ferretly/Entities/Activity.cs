using System.ComponentModel.DataAnnotations;

namespace Ferretly.Entities
{
  public class Activity
  {
    [Required]
    public int TypeId { get; set; }
    [Required]
    public ActivityType Type { get; set; }
    [Required]
    public int RoleId { get; set; }
    [Required]
    public Role Role { get; set; }
    [Required]
    public int ProjectId { get; set; }
    [Required]
    public Project Project { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    [Required]
    public Employee Employee { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int NumOfHours { get; set; }
    public string Description { get; set; }
  }
}
