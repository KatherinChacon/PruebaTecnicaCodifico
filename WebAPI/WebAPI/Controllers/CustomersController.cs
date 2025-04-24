using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiWebData _apiWebData;

        //Crear constructor
        public CustomersController(ApiWebData apiWebData)
        {
            _apiWebData = apiWebData;
        }

        //Peticiones
        [HttpGet]
        [Route("GetListaDatePrediction")]
        public async Task<IActionResult> GetListaDatePrediction()
        {
            List<ClientPrediction> ListaDatePrediction = await _apiWebData.ListaDatePrediction();

            return StatusCode(StatusCodes.Status200OK, ListaDatePrediction);
        }        
    }
}
