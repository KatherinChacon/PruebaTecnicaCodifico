using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly ApiWebData _apiWebData;

        //Crear constructor
        public ShippersController(ApiWebData apiWebData)
        {
            _apiWebData = apiWebData;
        }

        //Peticiones
        [HttpGet]
        [Route("GetListaShippers")]
        public async Task<IActionResult> GetListaShippers()
        {
            List<Shippers> ListaGetShippers = await _apiWebData.ListaGetShippers();

            return StatusCode(StatusCodes.Status200OK, ListaGetShippers);
        }
    }
}

