using Ferretly.Entities;

namespace Ferretly.Interfaces
{
  public interface IProjectRepository
  {
    void CreateProject(Project project);
    void DeleteProject(Project project);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(int id);
    Task<bool> ProjectExists(string name);
  }
}
