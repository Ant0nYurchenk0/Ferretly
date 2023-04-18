using Ferretly.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ferretly.DTOs
{
  public class ActivityDto
  {
    [Required]
    public int TypeId { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int NumOfHours { get; set; }
    public string Description { get; set; }
  }
}
