namespace Ferretly.Interfaces
{
  public interface IUnitOfWork
  {
    IProjectRepository ProjectRepository { get; }
    IActivityTypesRepository ActivityTypesRepository { get; }
    IRolesRepository RolesRepository { get; }
    IEmployeesRepository EmployeesRepository { get; }
    IActivitiesRepository ActivitiesRepository { get; }
    Task<bool> Complete();
  }
}
