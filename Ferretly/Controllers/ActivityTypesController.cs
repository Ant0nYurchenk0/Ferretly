using Ferretly.Data;
using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferretly.Controllers
{
  public class ActivityTypesController : BaseApiController
  {
    private IUnitOfWork _uow;
    public ActivityTypesController(IUnitOfWork uow)
    {
      _uow = uow;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityType>>> GetAllActivityTypes()
    {
      return Ok(await _uow.ActivityTypesRepository.GetAllActivityTypesAsync());
    }
  }
}
