using AutoMapper;
using Ferretly.Interfaces;

namespace Ferretly.Data
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
      _context = context;
    }
    public IProjectRepository ProjectRepository => new ProjectRepository(_context);

    public IActivityTypesRepository ActivityTypesRepository =>  new ActivityTypesRepository(_context);

    public IRolesRepository RolesRepository =>  new RolesRepository(_context);

    public IEmployeesRepository EmployeesRepository =>  new EmployeesRepository(_context);

    public IActivitiesRepository ActivitiesRepository => new ActivitiesRepository(_context);

    public async Task<bool> Complete()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}
