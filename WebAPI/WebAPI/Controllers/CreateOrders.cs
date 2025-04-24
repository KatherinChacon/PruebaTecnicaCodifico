using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateOrders : ControllerBase
    {        
        private readonly ApiWebData _apiWebData;

        //Crear constructor
        public CreateOrders(ApiWebData apiWebData)
        {
            _apiWebData = apiWebData;
        }

        //Peticion   
        [HttpPost]
        [Route("CrearOrder")]
        public async Task<IActionResult> CrearOrder([FromBody] NuevaOrdenRequest request)
        {
            bool respuesta = await _apiWebData.CrearNewOrder(request.Orden, request.Detalle);
            return StatusCode(StatusCodes.Status200OK, new {isSuccess = respuesta});
        }
    }
}
