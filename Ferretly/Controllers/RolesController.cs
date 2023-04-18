using Ferretly.Data;
using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferretly.Controllers
{
  public class RolesController : BaseApiController
  {
    private IUnitOfWork _uow;
    public RolesController(IUnitOfWork uow)
    {
      _uow = uow;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
    {
      return Ok(await _uow.RolesRepository.GetAllRolesAsync());
    }
  }
}
