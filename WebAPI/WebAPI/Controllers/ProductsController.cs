using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiWebData _apiWebData;

        //Crear constructor
        public ProductsController(ApiWebData apiWebData)
        {
            _apiWebData = apiWebData;
        }

        //Peticiones
        [HttpGet]
        [Route("GetListaProducts")]
        public async Task<IActionResult> GetListaProducts()
        {
            List<Products> ListaGetProducts = await _apiWebData.ListaGetProducts();

            return StatusCode(StatusCodes.Status200OK, ListaGetProducts);
        }
    }
}
