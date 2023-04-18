using AutoMapper;
using Ferretly.DTOs;
using Ferretly.Entities;

namespace Ferretly.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles() {
      CreateMap<Project, ProjectDto>();
      CreateMap<ProjectDto, Project>();
    }
  }
}
