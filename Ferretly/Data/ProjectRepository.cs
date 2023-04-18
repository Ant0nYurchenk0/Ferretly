using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ferretly.DTOs;
using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferretly.Data
{
  internal class ProjectRepository : IProjectRepository
  {
    private DataContext _context;

    public ProjectRepository(DataContext context)
    {
      _context = context;
    }

    public void CreateProject(Project project)
    {
      _context.Projects.Add(project);
    }

    public void DeleteProject(Project project)
    {
      _context.Projects.Remove(project);
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
      return await _context.Projects.ToListAsync();
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
      return await _context.Projects.FindAsync(id);
    }

    public async Task<bool> ProjectExists(string name)
    {
      return await _context.Projects.AnyAsync(p=>p.Name==name);
    }
  }
}