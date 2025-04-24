using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApiWebData _apiWebData;

        //Crear constructor
        public OrdersController(ApiWebData apiWebData)
        {
            _apiWebData = apiWebData;
        }

        //Peticiones
        [HttpGet]
        [Route("GetListaClientOrders")]
        public async Task<IActionResult> GetListaClientOrders()
        {
            List<ClientOrders> ListaGetClientOrders = await _apiWebData.ListaGetClientOrders();

            return StatusCode(StatusCodes.Status200OK, ListaGetClientOrders);
        }

        [HttpGet("ListaGetClientOrdersID/{id}")]
        public async Task<IActionResult> ListaGetClientOrdersID(int id)
        {
            var result = await _apiWebData.ListaGetClientOrdersID(id);
            return Ok(result);
        }
    }
}
