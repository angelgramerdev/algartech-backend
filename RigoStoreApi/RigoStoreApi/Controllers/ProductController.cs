using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RigoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IServiceProduct _serviceProduct;

        public ProductController(IServiceProduct serviceProduct) 
        { 
            _serviceProduct = serviceProduct;
        }

        [HttpGet]
        [Route("get_products")]
        public async Task<IActionResult> GetProducts() 
        {
            try 
            {
                var response=await _serviceProduct.GetProducts();
                return Ok(response);
            }
            catch (Exception ex) 
            { 
                return BadRequest();
            }
        
        }


    }
}
