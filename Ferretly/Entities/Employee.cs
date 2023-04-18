using System.ComponentModel.DataAnnotations;

namespace Ferretly.Entities
{
  public class Employee
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
  }
}
