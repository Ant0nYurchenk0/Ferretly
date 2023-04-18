using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ferretly.Entities
{
  public class Project
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

  }
}
