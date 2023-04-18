using Ferretly.Data;
using Ferretly.Entities;
using Ferretly.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferretly.Controllers
{
  public class EmployeesController : BaseApiController
  {
    private IUnitOfWork _uow;
    public EmployeesController(IUnitOfWork uow)
    {
      _uow = uow;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
    {
      return Ok(await _uow.EmployeesRepository.GetAlEmployeesAsync());
    }
  } 
}
