using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RigoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {

        private readonly IServiceOrderProduct _serviceOrderProduct;
        public OrderProductController(IServiceOrderProduct serviceOrderProduct) 
        { 
            _serviceOrderProduct = serviceOrderProduct;
        }

        [HttpPost]
        [Route("create_order_product")]
        public async Task<IActionResult> Create(OrderProduct orderProduct) 
        {
            try 
            {
                var response =await _serviceOrderProduct.Create(orderProduct);
                return Ok(response);
            }
            catch (Exception e) 
            { 
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get_order_products")]
        public async Task<IActionResult> GetOrderProducts(int orderId) 
        {
            try
            {
                var response = await _serviceOrderProduct.GetOrderProducts(orderId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
