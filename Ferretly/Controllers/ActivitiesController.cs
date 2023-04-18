using Ferretly.DTOs;
using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ferretly.Error;
using System.Net;

namespace Ferretly.Controllers
{
  public class ActivitiesController : BaseApiController
  {
    private IUnitOfWork _uow;

    public ActivitiesController(IUnitOfWork uow)
    {
      _uow = uow;
    }

    [HttpPost]
    public async Task<ActionResult<Activity>> CreateActivity([FromBody] ActivityDto activityDto)
    {
      if (activityDto == null) return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Activity cannot be null", string.Empty));
      var role = await _uow.RolesRepository.GetRoleByIdAsync(activityDto.RoleId);
      var employee = await _uow.EmployeesRepository.GetEmployeeByIdAsync(activityDto.EmployeeId);
      var type = await _uow.ActivityTypesRepository.GetActivityTypeByIdAsync(activityDto.TypeId);
      var project = await _uow.ProjectRepository.GetProjectByIdAsync(activityDto.ProjectId);
      if (role == null || employee == null || type == null || project == null) 
        return NotFound(new ApiException((int)HttpStatusCode.NotFound, "Dependency object(s) not found", string.Empty));
      if (await _uow.ActivitiesRepository.ActivityExists(activityDto.RoleId, activityDto.ProjectId, activityDto.EmployeeId, activityDto.TypeId))
        return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Activity with such properties already exists", string.Empty));
      var activity = new Activity
      {
        Description = activityDto.Description,
        NumOfHours = activityDto.NumOfHours,
        Date = activityDto.Date,
        RoleId = role.Id,
        EmployeeId = employee.Id,
        TypeId = type.Id,
        ProjectId = project.Id
      };
      _uow.ActivitiesRepository.CreateActivity(activity);
      if (await _uow.Complete()) return Ok(activity);
      return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Error when saving activity", string.Empty));
    }
    [HttpGet("{employeeId}/{date}")]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivityByDate(int employeeId, string date)
    {
      var activities = await _uow.ActivitiesRepository.GetActivityByDateAsync(employeeId, DateTime.Parse(date));
      if (activities == null) return NotFound(new ApiException((int)HttpStatusCode.NotFound, "No activities found", string.Empty));
      var response = new FormattedActivityDto()
      {
        Response = _uow.ActivitiesRepository.FormatActivity(activities)
      };
      return Ok(response);
    }
    [HttpGet("{employeeId}/{weekNum}/{year}")]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivityByDate(int employeeId, int weekNum, int year)
    {
      var activities = await _uow.ActivitiesRepository.GetActivityByWeekAsync(employeeId, weekNum, year);
      if (activities == null) return NotFound(new ApiException((int)HttpStatusCode.NotFound, "No activities found", string.Empty));
      var response = new FormattedActivityDto()
      {
        Response = _uow.ActivitiesRepository.FormatActivity(activities)
      };
      return Ok(response);
    }
  }
}
