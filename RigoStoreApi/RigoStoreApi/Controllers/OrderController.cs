using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infraestructure.Common;
using Application.Interfaces;

namespace RigoStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceOrder _serviceOrder;
      
        public OrderController(IServiceOrder serviceOrder) 
        { 
            _serviceOrder = serviceOrder;
        }

        [HttpPost]
        [Route("create_order")]
        public async Task<IActionResult> Create(Order entity) 
        {
            try
            {
                var response = await _serviceOrder.Create(entity);
                return Ok(response);
            }
            catch (Exception e) 
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get_orders")]
        public async Task<IActionResult> GetOrders() 
        {
            try
            {
                var response=await _serviceOrder.GetOrders();
                return Ok(response);    
            }
            catch (Exception e) 
            {
                return BadRequest();
            }
        }
    
    }
}
