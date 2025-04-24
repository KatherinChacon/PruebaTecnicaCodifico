using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApiWebData _apiWebData;

        //Crear constructor
        public EmployeesController(ApiWebData apiWebData)
        {
            _apiWebData = apiWebData;
        }

        //Peticiones
        [HttpGet]
        [Route("GetListaEmployees")]
        public async Task<IActionResult> GetListaEmployees()
        {
            List<Employees> ListaGetEmployees = await _apiWebData.ListaGetEmployees();

            return StatusCode(StatusCodes.Status200OK, ListaGetEmployees);
        }
    }
}
