using AutoMapper;
using Ferretly.DTOs;
using Ferretly.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ferretly.Entities;
using Ferretly.Error;
using System.Net;

namespace Ferretly.Controllers
{
  public class ProjectsController : BaseApiController
  {
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ProjectsController(IUnitOfWork uow, IMapper mapper)
    {
      _uow = uow;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
    {
      return Ok(await _uow.ProjectRepository.GetAllProjectsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProjectById(int id)
    {
      var project = await _uow.ProjectRepository.GetProjectByIdAsync(id);
      if(project == null) return NotFound(new ApiException((int)HttpStatusCode.NotFound, "Project not found", string.Empty));
      return Ok(project);
    }
    [HttpPost]
    public async Task<ActionResult> CreateProject([FromBody]ProjectDto projectDto)
    {
      if (projectDto == null) return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Project cannot be null", string.Empty));
      if (string.IsNullOrEmpty(projectDto.Name)) return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Project must have a name", string.Empty));
      if (await _uow.ProjectRepository.ProjectExists(projectDto.Name))
        return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Project with such name already exists", string.Empty));
      var project = new Project
      {
        Name = projectDto.Name,
        EndDate = projectDto.EndDate,
        StartDate = projectDto.StartDate,
      };
      _uow.ProjectRepository.CreateProject(project);
      if (await _uow.Complete()) return Ok(project);
      return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Error when saving project", string.Empty));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Project>> DeleteProject(int id)
    {
      var project = await _uow.ProjectRepository.GetProjectByIdAsync(id);
      if (project == null) return BadRequest(new ApiException((int)HttpStatusCode.NotFound, "Project not found", string.Empty));
      _uow.ProjectRepository.DeleteProject(project);
      if (await _uow.Complete()) return NoContent();
      return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Error when saving project", string.Empty));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProject([FromBody] ProjectDto projectDto, int id)
    {
      var project = await _uow.ProjectRepository.GetProjectByIdAsync(id);
      if (project == null) return NotFound(new ApiException((int)HttpStatusCode.NotFound, "Project not found", string.Empty));
      if (string.IsNullOrEmpty(projectDto.Name)) return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Project must have a name", string.Empty));
      if(await _uow.ProjectRepository.ProjectExists(projectDto.Name)) 
        return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Project with such name already exists", string.Empty));
      _mapper.Map(projectDto, project);
      if (await _uow.Complete()) return Ok(project);
      return BadRequest(new ApiException((int)HttpStatusCode.BadRequest, "Error when saving project", string.Empty));
    }
  }
}
