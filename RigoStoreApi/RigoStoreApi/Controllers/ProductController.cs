using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

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

        [HttpPost]
        [Route("create_product")]
        public async Task<IActionResult> Create(Product product) 
        {
            try
            {
                var response = await _serviceProduct.Create(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
