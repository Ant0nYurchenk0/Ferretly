using System.ComponentModel.DataAnnotations;

namespace Ferretly.DTOs
{
  public class ProjectDto
  {
    [Required]
    public string Name { get; set; }
    [Required] 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}
