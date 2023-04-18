using System.ComponentModel.DataAnnotations;

namespace Ferretly.Entities
{
  public class Role
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
  }
}
